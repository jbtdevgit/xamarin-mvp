using DryIoc;
using Xamarin_MVP.Common.APIService;
using Xamarin_MVP.Common.Manager;
using Xamarin_MVP.Ioc;
using Xamarin_MVP.Ioc.Modules;

namespace Xamarin_MVP.Common.Login
{
    public class LoginModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterType(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoginView>();
            containerRegistry.RegisterSingleton<ILoginManager, LoginManager>();
            containerRegistry.RegisterSingleton<ILoginAPIService, LoginAPIService>();
        }
    }
}
