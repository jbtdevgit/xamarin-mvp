namespace Xamarin_MVP.Ioc
{
    public interface IPlatformInitializer
    {
        void RegisterTypes(IContainerRegistry containerRegistry);
    }
}
