using System;

namespace Xamarin_MVP.Ioc
{
    public interface IContainerRegistry
    {
        IContainerRegistry Register(Type from, Type to);
        IContainerRegistry RegisterSingleton(Type from, Type to);
    }
}
