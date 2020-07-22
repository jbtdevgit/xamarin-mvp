using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Entities;

namespace Xamarin_MVP.Common.APIService
{
    public interface IListAPIService
    {
        Task<IEnumerable<StoreEntity>> GetCollectionOfStores();
        Task<bool> AddStore(StoreEntity storeDetail);
    }
}
