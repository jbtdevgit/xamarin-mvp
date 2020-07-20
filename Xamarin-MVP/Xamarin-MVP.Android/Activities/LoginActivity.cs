using System;

using Android.App;
using Android.OS;
using Android.Text;
using Android.Widget;
using DryIoc;
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
        private TextView ErrorMessage;

        public void ClearError()
        {
            ErrorMessage = null;
        }

        public void GoToNextScreen()
        {
            Toast.MakeText(this, "Success", ToastLength.Long).Show();
        }

        public void OnInvalidCredentials(string message)
        {
            LoginButton.Enabled = false;
            ErrorMessage.Text = message;
        }

        public void OnLoginButtonEnabled(bool isEnabled)
        {
           
        }

        public override void OnNetworkError()
        {
        }

        public void OnStopWaiting()
        {
            
        }

        public void OnWaiting()
        {
            
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

            MainDroidApplication.ContainerRegistry.Register<ILoginView, LoginActivity>();

            CreatePresenter(savedInstanceState);
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            await Presenter.Login();
        }

        private void PasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            Presenter.UpdatePassword(e.Text.ToString());
        }

        private void UsernameTextChanged(object sender, TextChangedEventArgs e)
        {
            Presenter.UpdateUsername(e.Text.ToString());
        }

    }
}