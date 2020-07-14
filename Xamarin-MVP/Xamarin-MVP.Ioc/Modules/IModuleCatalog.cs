using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleCatalog
    {
        IEnumerable<IModuleInfo> Modules { get; }
        IModuleCatalog AddModule(IModuleInfo moduleInfo);
        void Initialize();
    }
}
