
using Xamarin_MVP.Ioc;
using Xamarin_MVP.Ioc.Modules;

namespace Xamarin_MVP.Common
{
    public abstract class BaseApplication
    {
        IContainerExtension ContainerExtension;
        IModuleCatalog ModuleCatalog;
        public IContainerProvider Container => ContainerExtension;

        public BaseApplication()
        {
            InitializeItems();
        }

        private void InitializeItems()
        {
            Init();
        }

        private void Init()
        {
            ContainerLocator.SetContainerExtension(CreateContainerExtension);
            ContainerExtension = ContainerLocator.CurrentContainerExtension;
            RegisterTypes(ContainerExtension);
            ModuleCatalog = Container.Resolve<IModuleCatalog>();
            ConfigureModuleCatalog(ModuleCatalog);
        }

        protected virtual void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) { }

        protected abstract IContainerExtension CreateContainerExtension();

        protected abstract void RegisterTypes(IContainerRegistry containerRegistry);

    }
}
