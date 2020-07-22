using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin_MVP.Common.APIService;
using Xamarin_MVP.Common.Constants;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.Services;

namespace Xamarin_MVP.Common.Manager
{
    public class ListManager : IListManager
    {
        IListAPIService ListAPIService;

        public ListManager(IListAPIService listAPIService)
        {
            ListAPIService = listAPIService;
        }

        public async Task<ValidateService<APIResponseEnum>> AddStore(StoreEntity storeDetail)
        {
            bool result = await ListAPIService.AddStore(storeDetail);

            if (result)
            {
                return new ValidateService<APIResponseEnum>(APIResponseEnum.AddeddSuccessfully);
            }
            else
            {
                return new ValidateService<APIResponseEnum>(APIResponseEnum.NotAdded);
            }
        }

        public async Task<IEnumerable<StoreEntity>> GetCollectionOfStores()
        {
            return await ListAPIService.GetCollectionOfStores();
        }
    }
}
