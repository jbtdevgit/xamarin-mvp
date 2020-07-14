namespace Xamarin_MVP.Ioc.Modules
{
    public static class ModuleCatalogExtension
    {
        public static IModuleCatalog AddModule<T>(this IModuleCatalog moduleCatalog, InitMode mode = InitMode.WhenAvailable)
            where T : IModule => moduleCatalog.AddModule<T>(typeof(T).Name, mode);

        public static IModuleCatalog AddModule<T>(this IModuleCatalog moduleCatalog, string name)
            where T : IModule => moduleCatalog.AddModule<T>(name, InitMode.WhenAvailable);

        public static IModuleCatalog AddModule<T>(this IModuleCatalog moduleCatalog, string name, InitMode mode)
            where T : IModule => moduleCatalog.AddModule(new ModuleInfo(typeof(T), name, mode));
    }
}
