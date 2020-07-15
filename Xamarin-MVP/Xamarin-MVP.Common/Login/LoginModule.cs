using DryIoc;
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
        }
    }
}
