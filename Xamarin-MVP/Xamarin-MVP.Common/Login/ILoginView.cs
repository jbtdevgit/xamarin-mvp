namespace Xamarin_MVP.Common.Login
{
    public interface ILoginView : IBaseView
    {
        void OnWaiting();
        void OnStopWaiting();
        void GoToNextScreen();
        void ClearError();
        void OnInvalidCredentials(string message);
        void OnLoginButtonEnabled(bool isEnabled);
    }
}
