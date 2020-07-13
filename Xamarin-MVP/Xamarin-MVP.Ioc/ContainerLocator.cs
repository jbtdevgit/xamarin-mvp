using System;

namespace Xamarin_MVP.Ioc
{
    public static class ContainerLocator
    {
        private static Lazy<IContainerExtension> LazyContainerExtension;
        private static IContainerExtension _CurrentContainerExtension;

        public static IContainerExtension CurrentContainerExtension =>
            _CurrentContainerExtension ?? (_CurrentContainerExtension = LazyContainerExtension?.Value);

        public static IContainerProvider Container =>
            CurrentContainerExtension;

        public static void SetContainerExtension(Func<IContainerExtension> Factory) =>
            LazyContainerExtension = new Lazy<IContainerExtension>(Factory);

        public static void ResetContainer()
        {
            LazyContainerExtension = null;
        }

    }
}
