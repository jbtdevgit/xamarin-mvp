using System;

using Android.App;

namespace Xamarin_MVP.Android.Helpers
{
    /// <summary>
    /// Gets the current instance of the activity while avoiding memory leaks
    /// </summary>
    public static class GetActivityInstance
    {
        public static WeakReference<Activity> ActivityRef;
        public static void UpdateActivity(Activity activity)
        {
            ActivityRef = new WeakReference<Activity>(activity);
        }
    }
}