using System;

using Android.App;
using Android.Runtime;
using Xamarin_MVP.Common;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android
{
    [Application]
    public class MainDroidApplication : BaseDroidApplication
    {
        public static MainDroidApplication Current { get; set; }
        public static App Application { get; set; }
        public static IContainerRegistry ContainerRegistry { get; set; }

        protected MainDroidApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Application = LoadApp();
        }

        protected App LoadApp()
        {
            return new App(new AndroidInitializer());
        }

        private class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                ContainerRegistry = containerRegistry;
            }
        }

    }
}