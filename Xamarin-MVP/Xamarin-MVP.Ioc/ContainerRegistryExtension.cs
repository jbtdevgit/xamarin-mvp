using System;

namespace Xamarin_MVP.Ioc
{
    public static class ContainerRegistryExtension
    {
        public static IContainerRegistry Register<T>(this IContainerRegistry containerRegistry)
        {
            return containerRegistry.Register(typeof(T));
        }

        public static IContainerRegistry RegisterSingleton<T>(this IContainerRegistry containerRegistry)
        {
            return containerRegistry.RegisterSingleton(typeof(T));
        }

        public static IContainerRegistry RegisterSingleton<TFrom, TTo>(this IContainerRegistry containerRegistry) where TTo : TFrom
        {
            return containerRegistry.RegisterSingleton(typeof(TFrom), typeof(TTo));
        }

        public static IContainerRegistry RegisterSingleton<T>(this IContainerRegistry containerRegistry, Func<IContainerProvider, object> factoryMethod)
        {
            return containerRegistry.RegisterSingleton(typeof(T), factoryMethod);
        }

        public static IContainerRegistry RegisterSingleton<T>(this IContainerRegistry containerRegistry, Func<object> factoryMethod)
        {
            return containerRegistry.RegisterSingleton(typeof(T), factoryMethod);
        }
    }
}
