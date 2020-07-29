using System;

using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Xamarin_MVP.Android.Helpers;
using Xamarin_MVP.Common;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.List;
using Xamarin_MVP.Ioc;

namespace Xamarin_MVP.Android.Activities
{
    public class ListActivity : MainActivity<ListPresenter>, IListView
    {
        protected override IBaseView BaseView => this;
        FloatingActionButton buttonAdd;
        RecyclerView 

        public void GoToNextScreen()
        {
            
        }

        public void GoToStoreDetails(StoreEntity storeDetail = null)
        {
            
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
            SetContentView(Resource.Layout.LoginView);

            GetActivityInstance.UpdateActivity(this);

            CreatePresenter(savedInstanceState);
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