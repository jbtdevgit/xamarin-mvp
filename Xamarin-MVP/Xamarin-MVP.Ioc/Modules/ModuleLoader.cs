using System;

namespace Xamarin_MVP.Ioc.Modules
{
    public class ModuleLoader : IModuleLoader
    {
        IContainerExtension Container;

        public ModuleLoader(IContainerExtension container)
        {
            Container = container;
        }
        public void Initialize(IModuleInfo moduleInfo)
        {
            var module = CreateModule(Type.GetType(moduleInfo.ModuleType, true));
            if(module != null)
            {
                module.RegisterType(Container);
                module.OnInitialized(Container);
            }
        }

        protected virtual IModule CreateModule(Type moduleType)
        {
            return (IModule)Container.Resolve(moduleType);
        }
    }
}
