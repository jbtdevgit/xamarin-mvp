using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Constants;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.Manager;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.List
{
    public class ListInteractor : IListInteractor
    {
        IListManager ListManager;

        public ListInteractor(IListManager listManager)
        {
            ListManager = listManager;
        }

        public async Task<ValidateService<APIResponseEnum>> AddStore(StoreEntity storeDetail)
        {
            return await ListManager.AddStore(storeDetail);
        }

        public async Task<IEnumerable<StoreEntity>> GetStores()
        {
            return await ListManager.GetCollectionOfStores();
        }
    }
}
