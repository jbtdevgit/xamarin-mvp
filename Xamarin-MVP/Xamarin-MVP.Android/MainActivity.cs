using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Content.PM;
using Android.Widget;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public abstract class MainActivity : AppCompatActivity
    {
        protected abstract IPlatformInitializer PlatformInitializer { get; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);  
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum]Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}