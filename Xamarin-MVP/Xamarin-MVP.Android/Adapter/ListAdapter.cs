using System.Collections.Generic;

using Android.App;
using Xamarin_MVP.Common.Entities;
using Xamarin_MVP.Common.List;

namespace Xamarin_MVP.Android.Adapter
{
    public class ListAdapter : ItemsAdapter<StoreEntity>
    {
        readonly ListPresenter presenter;

        public ListAdapter(Activity activity, List<StoreEntity> collection) : base(activity, collection)
        {
            this.presenter.CollectionOfStore.CollectionChanged += (sender, args) =>
            {
                activity.RunOnUiThread(NotifyDataSetChanged);
            };
        }

        public override int GetResourceLayoutId()
        {
            return 0;
        }
    }
}