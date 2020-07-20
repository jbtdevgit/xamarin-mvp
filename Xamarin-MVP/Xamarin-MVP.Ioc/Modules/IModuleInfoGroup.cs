using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleInfoGroup : IModuleCatalogItem, IList<IModuleInfo>, IList
    {
        InitMode InitializeMode { get; set; }

    }
}
