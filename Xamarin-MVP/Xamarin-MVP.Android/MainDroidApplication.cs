using System;

using Android.App;
using Android.Runtime;
using Xamarin_MVP.Common;

namespace Xamarin_MVP.Android
{
    [Application]
    public class MainDroidApplication : BaseDroidApplication
    {
        public static MainDroidApplication Current { get; set; }
        protected MainDroidApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            LoadApp(new App());
        }

    }
}