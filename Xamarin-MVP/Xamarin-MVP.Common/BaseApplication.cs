
using System;
using System.Linq;
using System.Reflection;
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
            RegisterRequiredTypes(ContainerExtension);
            RegisterTypes(ContainerExtension);
            ModuleCatalog = Container.Resolve<IModuleCatalog>();
            ConfigureModuleCatalog(ModuleCatalog);
            ContainerExtension.CreateScope();

            InitializeModules();
        }

        private void RegisterRequiredTypes(IContainerExtension containerExtension)
        {
            containerExtension.RegisterSingleton<IModuleCatalog, ModuleCatalog>();
            containerExtension.RegisterSingleton<IModuleManager, ModuleManager>();
            containerExtension.RegisterSingleton<IModuleLoader, ModuleLoader>();
        }

        private void InitializeModules()
        {
            if (ModuleCatalog.Modules.Any())
            {
                IModuleManager manager = Container.Resolve<IModuleManager>();
                manager.RunManager();
            }
        }

        protected virtual void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) { }

        protected abstract IContainerExtension CreateContainerExtension();

        protected abstract void RegisterTypes(IContainerRegistry containerRegistry);

    }
}
