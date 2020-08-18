using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Xamarin_MVP.Android.Adapter;
using Xamarin_MVP.Android.Helpers;
using Xamarin_MVP.Common;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.List;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android.Activities
{
    [Activity(Label = "ListActivity")]
    public class ListActivity : MainActivity<ListPresenter>, IListView
    {
        protected override IBaseView BaseView => this;
        FloatingActionButton buttonAdd;
        RecyclerView recyclerView;
        Toolbar toolbar;
        ListAdapter itemAdapter;

        public void GoToNextScreen()
        {
           
        }

        public void GoToStoreDetails(string storeDetail = null)
        {
            using (Intent intent = new Intent(this, typeof(ItemDetailActivity)))
            {
                using(Bundle bundle = new Bundle())
                {
                    bundle.PutString("storeDetail", storeDetail);
                    intent.PutExtras(bundle);

                    StartActivity(intent);
                }
            }
        }

        public override void OnNetworkError()
        {
            
        }

        public void OnStopWaiting()
        {
           
        }

        public void OnWaiting()
        {
            
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListView_layout);
            GetActivityInstance.UpdateActivity(this);

            buttonAdd = FindViewById<FloatingActionButton>(Resource.Id.btn_add);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.HasFixedSize = true;

            CreatePresenter(savedInstanceState);

            
            recyclerView.SetAdapter(itemAdapter = new ListAdapter(this, Presenter.CollectionOfStore));
            itemAdapter.ItemClick += OnItemCLick;
            buttonAdd.Click += buttonAddClick;
            
        }

        private void buttonAddClick(object sender, EventArgs e)
        {
            Presenter.AddItem();
        }

        private void OnItemCLick(object sender, StoreEntity e)
        {
            Presenter.ViewStore(e);
        }

        protected override ListPresenter GetPresenter()
        {
            bool result = GetActivityInstance.ActivityRef.TryGetTarget(out Activity target);

            if (result)
            {
                MainDroidApplication.ContainerRegistry.RegisterInstance<IListView>((ListActivity)target);
                return MainDroidApplication.Application.Container.Resolve<ListPresenter>();
            }

            return null;
        }


    }
}