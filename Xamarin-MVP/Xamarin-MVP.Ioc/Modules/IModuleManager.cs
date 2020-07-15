namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleManager
    {
        void RunManager();
        void LoadModule(string moduleName);

    }
}
