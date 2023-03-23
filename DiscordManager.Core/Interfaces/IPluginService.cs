using DCM.Core.Enums;

namespace DCM.Core.Interfaces;

public interface IPluginService
{
    List<FileInfo> PluginFiles { get; }
    List<DCMPlugin> PluginInstances { get; }
    List<Type> PluginTypes { get; }
    void Invoke(PluginInvokationTarget target);
    int Load();
}