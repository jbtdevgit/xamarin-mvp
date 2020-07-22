using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Entities;

namespace Xamarin_MVP.Common.APIService
{
    public class ListAPIService : IListAPIService
    {

        public List<StoreEntity> DefaultCollection = new List<StoreEntity>()
        {
            new StoreEntity
            {
                StoreID = 1,
                StoreAddress = "Okinawa, Japan",
                StoreName = "CallItBakeTools",
                StoreType = StoreType.Baking
            },
            new StoreEntity
            {
                StoreID = 2,
                StoreAddress = "Melbourne, Australia",
                StoreName = "CarveIt",
                StoreType = StoreType.Carpentry
            }
        };

        public Task<bool> AddStore(StoreEntity storeDetail)
        {
            DefaultCollection.Add(storeDetail);
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<StoreEntity>> GetCollectionOfStores()
        {
            await Task.Delay(2000);
            return DefaultCollection;
        }
    }
}
