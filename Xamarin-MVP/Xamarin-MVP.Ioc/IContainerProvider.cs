using System;

namespace Xamarin_MVP.Ioc
{
    public interface IContainerProvider
    {
        object Resolve(Type type);
        object Resolve(Type type, params (Type Type, object Instance)[] paramaters);
        object Resolve(Type type, string name);
        object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters);
        IScopedProvider CreateScope();
        IScopedProvider CurrentScope { get; }
    }
}
