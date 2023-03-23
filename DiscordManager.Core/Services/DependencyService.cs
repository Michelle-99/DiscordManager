﻿using System.Reflection;
using DCM.Core.Attributes;
using DCM.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DCM.Core.Services;

public class DependencyService : IDependencyService
{
    public IServiceCollection Services { get; } = new ServiceCollection();

    public object CreateInstance(Type type, IServiceCollection dependencies)
    {
        var constructor = GetConstructor(type: type);
        if (constructor is null)
            return Activator.CreateInstance(type: type);

        var parameters = GetParameters(constructor: constructor, secondarySource: dependencies);
        return constructor.Invoke(parameters: parameters);
    }

    public T CreateInstance<T>(IServiceCollection collection) where T : class
    {
        return (T)CreateInstance(typeof(T), dependencies: collection);
    }

    public void PublishServices(
        IDiscordService discordService,
        IEventService eventService)
    {
        Services.AddSingleton(implementationInstance: discordService);
        Services.AddSingleton(implementationInstance: eventService);
    }

    public IEnumerable<ServiceDescriptor> SearchInjectables(Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(x => x.IsClass)
            .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(InjectableAttribute)))
            .Select(x =>
            {
                var attribute = x.CustomAttributes.First(y => y.AttributeType == typeof(InjectableAttribute));
                var @interface = attribute.ConstructorArguments.FirstOrDefault().Value as Type;
                return new ServiceDescriptor(
                    @interface ?? x,
                    implementationType: x,
                    lifetime: ServiceLifetime.Singleton);
            });
    }

    private static ConstructorInfo GetConstructor(Type type)
    {
        var constructors = type.GetConstructors();
        return constructors.Length switch
        {
            > 1 => throw new InvalidOperationException("Multiple Constructors were found! Cannot create an instance!"),
            0 => null,
            _ => constructors.First()
        };
    }


    private object[] GetParameters(ConstructorInfo constructor, IServiceCollection secondarySource)
    {
        var provider = MergeServices(secondary: secondarySource);
        return constructor
            .GetParameters()
            .Select(x => x.ParameterType)
            .Select(x => provider.GetService(serviceType: x))
            .ToArray();
    }

    private ServiceProvider MergeServices(IServiceCollection secondary)
    {
        var source = new ServiceCollection();
        var services = source.Concat(second: Services).Concat(second: secondary);
        source.Add(descriptors: services);
        var provider = source.BuildServiceProvider();
        return provider;
    }
}