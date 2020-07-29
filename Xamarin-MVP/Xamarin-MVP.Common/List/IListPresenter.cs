using System.Threading.Tasks;
using Xamarin_MVP.Common.Entities;

namespace Xamarin_MVP.Common.List
{
    public interface IListPresenter
    {
        Task LoadCollectionOfStores();
        void ViewStore(StoreEntity storeDetail);
        Task DeleteStores();
    }
}
