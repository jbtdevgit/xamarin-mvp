using DryIoc;
using Xamarin_MVP.Common.Login;
using Xamarin_MVP.Ioc;
using Xamarin_MVP.Ioc.Modules;

namespace Xamarin_MVP.Common
{
    public abstract class Application : BaseApplication
    {
        protected Application() : base()
        { }

        protected override IContainerExtension CreateContainerExtension()
        {
            return new DryIocContainerExtension(new Container(CreateContainerRules()));
        }

        protected virtual Rules CreateContainerRules() => DryIocContainerExtension.DefaultRules;

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoginView>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<LoginModule>();
        }
    }
}
