using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin_MVP.Common;
using Xamarin_MVP.Common.Login;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : MainActivity<LoginPresenter>, ILoginView
    {
        protected override IBaseView BaseView => this;

        public override void OnNetworkError()
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginView);


            CreatePresenter(savedInstanceState);
        }


    }
}