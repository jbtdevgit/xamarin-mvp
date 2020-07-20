using System;
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
            containerRegistry.RegisterSingleton<ILoginManager, LoginManager>();
            containerRegistry.RegisterSingleton<ILoginAPIService, LoginAPIService>();
            containerRegistry.RegisterSingleton<ILoginInteractor, LoginInteractor>();
        }
    }
}
