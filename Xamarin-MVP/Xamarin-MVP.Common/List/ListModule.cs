using DryIoc;
using Xamarin_MVP.Common.APIService;
using Xamarin_MVP.Common.Manager;
using Xamarin_MVP.Ioc;
using Xamarin_MVP.Ioc.Modules;

namespace Xamarin_MVP.Common.List
{
    public class ListModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterType(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IListInteractor, ListInteractor>();
            containerRegistry.Register<IListAPIService, ListAPIService>();
            containerRegistry.Register<IListManager, ListManager>();
        }
    }
}
