using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin_MVP.Common.Entities;

namespace Xamarin_MVP.Common.List
{
    public class ListPresenter : BasePresenter<IListView>, IListPresenter
    {
        IListInteractor ListInteractor { get; }
        public ObservableCollection<StoreEntity> CollectionOfStore { get; set; }
        bool _pendingRequest;

        public ListPresenter(IListView view, IListInteractor listInteractor) : base(view)
        {
            ListInteractor = listInteractor;
        }

        public override void Destroy()
        {
            
        }

        public override Task Init()
        {
           
        }

        public override async Task RestoreState(IList<string> savedStates)
        {
            CollectionOfStore = JsonConvert.DeserializeObject<ObservableCollection<StoreEntity>>(savedStates[0]);
            _pendingRequest = JsonConvert.DeserializeObject<bool>(savedStates[1]);

            if (_pendingRequest)
            {
                await GetCollectionOfStores();
            }
        }

        public override IList<string> SaveStates()
        {
            List<string> savedStates = new List<string>
            {
                JsonConvert.SerializeObject(CollectionOfStore),
                JsonConvert.SerializeObject(_pendingRequest)
            };

            return savedStates;
        }

        public async Task GetCollectionOfStores()
        {
            await ListInteractor.GetStores();
        }
    }
}
