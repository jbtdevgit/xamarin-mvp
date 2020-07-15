using System;
using System.Collections.Generic;
using System.Linq;

namespace Xamarin_MVP.Ioc.Modules
{
    public class ModuleManager : IModuleManager
    {
        protected IModuleCatalog ModuleCatalog { get; }
        protected IModuleLoader ModuleLoader { get; }

        public ModuleManager(IModuleLoader moduleLoader, IModuleCatalog moduleCatalog)
        {
            ModuleLoader = moduleLoader;
            ModuleCatalog = moduleCatalog;
        }

        public void RunManager()
        {
            LoadModulesWithInitModeWhenAvailable();
        }

        protected void LoadModulesWithInitModeWhenAvailable()
        {
            IEnumerable<IModuleInfo> WhenAvailableModules = ModuleCatalog.Modules.Where(x => x.InitializeMode.Equals(InitMode.WhenAvailable));
            if(WhenAvailableModules != null)
            {
                LoadModules(WhenAvailableModules);
            }
        }

        public void LoadModule(string moduleName)
        {
            IEnumerable<IModuleInfo> modules = ModuleCatalog.Modules.Where(x => x.Name.Equals(moduleName));
            if(modules == null || modules.Count().Equals(0))
            {
                throw new Exception();
            }
            else if(modules.Count() > 1)
            {
                throw new Exception();
            }

            LoadModules(modules);
        }

        protected virtual void LoadModules(IEnumerable<IModuleInfo> modules)
        {
            foreach(IModuleInfo module in modules)
            {
                try
                {
                    ModuleLoader.Initialize(module);
                }
                catch(Exception e)
                {
                    
                }
            }
        }

       
    }
}
