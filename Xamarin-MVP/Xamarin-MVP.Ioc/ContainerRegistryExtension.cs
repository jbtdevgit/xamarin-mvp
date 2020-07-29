using System;

namespace Xamarin_MVP.Ioc
{
    public static class ContainerRegistryExtension
    {
        public static IContainerRegistry RegisterInstance<TInterface>(this IContainerRegistry containerRegistry, TInterface instance)
        {
            return containerRegistry.RegisterInstance(typeof(TInterface), instance);
        }

        public static IContainerRegistry Register<T>(this IContainerRegistry containerRegistry)
        {
            return containerRegistry.Register(typeof(T));
        }

        public static IContainerRegistry Register<TFrom, TTo>(this IContainerRegistry containerRegistry) where TTo : TFrom
        {
            return containerRegistry.Register(typeof(TFrom), typeof(TTo));
        }

        public static void RegisterInterface<TInterface>(this IContainerRegistry containerRegistry, string name = null)
        {
            var typeOfView = typeof(TInterface);

            if (string.IsNullOrWhiteSpace(name))
            {
                name = typeOfView.Name;
            }

            containerRegistry.RegisterInterface(typeOfView, name);
        }

        public static void RegisterInterface(this IContainerRegistry containerRegistry, Type typeOfView, string name)
        {
            containerRegistry.Register(typeof(object), typeOfView, name);
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
