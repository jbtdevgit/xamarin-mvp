namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleInfo : IModuleCatalogItem
    {
        string Name { get; set; }
        string ModuleType { get; set; }
        InitMode InitializeMode { get; set; }
    }
}
