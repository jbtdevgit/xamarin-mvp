namespace Xamarin_MVP.Common.List
{
    public interface IListView : IBaseView
    {
        void OnWaiting();
        void OnStopWaiting();
        void GoToNextScreen();
    }
}
