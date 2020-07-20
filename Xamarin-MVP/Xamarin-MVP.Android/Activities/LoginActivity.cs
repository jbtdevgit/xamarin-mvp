using System;

using Android.App;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using DryIoc;
using Xamarin_MVP.Android.Helpers;
using Xamarin_MVP.Common;
using Xamarin_MVP.Common.Login;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : MainActivity<LoginPresenter>, ILoginView
    {
        protected override IBaseView BaseView => this;

        EditText UsernameInput;
        EditText PasswordInput;
        Button LoginButton;
        TextView ErrorMessage;
        ProgressBar ProgressBar;

        public void ClearError()
        {
            ErrorMessage.Text = string.Empty;
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
            LoginButton.Enabled = isEnabled;
        }

        public override void OnNetworkError()
        {
        }

        public void OnStopWaiting()
        {
            ProgressBar.Visibility = ViewStates.Gone;
        }

        public void OnWaiting()
        {
            ProgressBar.Visibility = ViewStates.Visible;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginView);

            UsernameInput = FindViewById<EditText>(Resource.Id.editText_username);
            PasswordInput = FindViewById<EditText>(Resource.Id.editText_password);
            LoginButton = FindViewById<Button>(Resource.Id.button_login);
            ErrorMessage = FindViewById<TextView>(Resource.Id.error_login_message);
            ProgressBar = FindViewById<ProgressBar>(Resource.Id.activity_indicator);

            UsernameInput.TextChanged += UsernameTextChanged;
            PasswordInput.TextChanged += PasswordTextChanged;
            LoginButton.Click += LoginButtonClicked;


            GetActivityInstance.UpdateActivity(this);

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

        protected override LoginPresenter GetPresenter()
        {
            bool result = GetActivityInstance.ActivityRef.TryGetTarget(out Activity target);

            if (result)
            {
                MainDroidApplication.ContainerRegistry.RegisterInstance<ILoginView>((LoginActivity)target);
                return MainDroidApplication.Application.Container.Resolve<LoginPresenter>();
            }

            return null;          
        }
    }
}