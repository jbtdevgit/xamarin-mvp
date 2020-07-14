using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin_MVP.Ioc.Modules
{
    public interface IModuleInfo
    {
        string Name { get; set; }
        string ModuleType { get; set; }
        InitMode InitializeMode { get; set; }
    }
}
