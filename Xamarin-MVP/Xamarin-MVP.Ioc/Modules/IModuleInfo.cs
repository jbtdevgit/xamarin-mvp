namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleInfo
    {
        string Name { get; set; }
        string ModuleType { get; set; }
        InitMode InitializeMode { get; set; }
    }
}
