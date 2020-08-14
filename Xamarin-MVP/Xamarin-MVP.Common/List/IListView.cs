using Xamarin_MVP.Common.Entities;

namespace Xamarin_MVP.Common.List
{
    public interface IListView : IBaseView
    {
        void OnWaiting();
        void OnStopWaiting();
        void GoToNextScreen();
        void GoToStoreDetails(string storeDetail = null);
    }
}
