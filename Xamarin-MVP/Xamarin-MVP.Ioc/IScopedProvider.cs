using System;

namespace Xamarin_MVP.Ioc
{
    public interface IScopedProvider : IContainerProvider, IDisposable
    {
        bool IsAttached { get; set; }
    }
}
