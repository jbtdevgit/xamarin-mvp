namespace Xamarin_MVP.Ioc
{
    public static class ContainerProviderExtension
    {
        public static T Resolve<T>(this IContainerProvider containerProvider)
        {
            return (T)containerProvider.Resolve(typeof(T));
        }

        public static T Resolve<T>(this IContainerProvider containerProvider, string name)
        {
            return (T)containerProvider.Resolve(typeof(T), name);
        }
    }
}
