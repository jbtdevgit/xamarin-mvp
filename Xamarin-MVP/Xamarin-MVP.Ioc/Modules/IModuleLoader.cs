using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleLoader
    {
        void Initialize(IModuleInfo moduleInfo);
    }
}
