using DryIoc;
using System;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Common
{
    public abstract class BaseApplication
    {
        IContainerExtension ContainerExtension;

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
        }

        protected abstract IContainerExtension CreateContainerExtension();

        protected abstract void RegisterTypes(IContainerRegistry containerRegistry);

    }
}
