using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Constants;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.List
{
    public interface IListInteractor
    {
        Task<IEnumerable<StoreEntity>> GetStores();
        Task<ValidateService<APIResponseEnum>> AddStore(StoreEntity storeDetail);
    }
}
