namespace DCM.Core.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class InjectableAttribute : Attribute
{
    public InjectableAttribute(Type @interface = null)
    {
        Interface = @interface;
    }

    public Type Interface { get; }
}