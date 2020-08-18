using Xamarin_MVP.Common.List;
using Xamarin_MVP.Common.Login;
using Xamarin_MVP.Ioc;
using Xamarin_MVP.Ioc.Modules;

namespace Xamarin_MVP.Common
{
    public class App : Application
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<LoginModule>();
            moduleCatalog.AddModule<ListModule>();
        }
    }
}
