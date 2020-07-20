using Android.Runtime;
using System;
using Xamarin_MVP.Common;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android
{
    public class BaseDroidApplication : global::Android.App.Application
    {
        protected BaseDroidApplication(IntPtr javaReference, JniHandleOwnership transfer)
        {
        }
    }
}