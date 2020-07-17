using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
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
        private EditText UsernameInput;
        private EditText PasswordInput;
        private Button LoginButton;
        private TextView ErrroMessage;

        public void ClearError()
        {
            throw new NotImplementedException();
        }

        public void GoToNextScreen()
        {
            throw new NotImplementedException();
        }

        public void OnInvalidCredentials(string message)
        {
            throw new NotImplementedException();
        }

        public void OnLoginButtonEnabled(bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public override void OnNetworkError()
        {
        }

        public void OnStopWaiting()
        {
            throw new NotImplementedException();
        }

        public void OnWaiting()
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginView);

            UsernameInput = FindViewById<EditText>(Resource.Id.editText_username);
            PasswordInput = FindViewById<EditText>(Resource.Id.editText_password);
            LoginButton = FindViewById<Button>(Resource.Id.button_login);

            UsernameInput.TextChanged += UsernameTextChanged;
            PasswordInput.TextChanged += PasswordTextChanged;
            LoginButton.Click += LoginButtonClicked;


            CreatePresenter(savedInstanceState);
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UsernameTextChanged(object sender, TextChangedEventArgs e)
        {
            Presenter.Updatepassword
        }
    }
}