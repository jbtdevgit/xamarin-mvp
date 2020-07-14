using DryIoc;
using System;

namespace Xamarin_MVP.Ioc
{
    public interface IContainerRegistry
    {
        IContainerRegistry Register(Type T);
        IContainerRegistry Register(Type from, Type to);
        IContainerRegistry Register(Type from, Type to, string name);
        IContainerRegistry Register(Type type, Func<object> factoryMethod);
        IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod);
        IContainerRegistry RegisterSingleton(Type T);
        IContainerRegistry RegisterSingleton(Type from, Type to);
        IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod);
        IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod);
    }
}
