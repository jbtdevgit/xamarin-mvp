using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Constants;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Manager
{
    public interface IListManager
    {
        Task<IEnumerable<StoreEntity>> GetCollectionOfStores();
        Task<ValidateService<APIResponseEnum>> AddStore(StoreEntity storeDetail);
    }
}
