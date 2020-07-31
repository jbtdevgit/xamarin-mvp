using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace Xamarin_MVP.Android.Adapter
{
    public abstract class ItemsAdapter<T> : RecyclerView.Adapter where T : class
    {
        List<T> Collection;
        public override int ItemCount => Collection.Count();
        public abstract int GetResourceLayoutId();

        public event EventHandler<T> ItemClick;
        public event EventHandler<T> ItemLongClick;

        readonly Activity Activity;

        void OnClick(int position) => ItemClick?.Invoke(this, Collection[position]);
        void OnLongClick(int position) => ItemLongClick?.Invoke(this, Collection[position]);


        public ItemsAdapter()
        {
            Collection = new List<T>();
        }

        public ItemsAdapter(Activity activity, List<T> collection)
        {
            Activity = activity;
            Collection = collection; 
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Binder<T> vh = holder as Binder<T>;
            vh.Bind(Collection[position]);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                         Inflate(GetResourceLayoutId(), parent, false);

            ItemsViewHolder item = new ItemsViewHolder(itemView, OnClick, OnLongClick);
            return item;
        }

        class ItemsViewHolder : RecyclerView.ViewHolder
        {
            public ItemsViewHolder(View itemView, Action<int> onClickListener, Action<int> onLongClickListener) : base(itemView)
            {
                itemView.Click += (sender, e) => onClickListener(AdapterPosition);
                itemView.LongClick += (sender, e) => onLongClickListener(AdapterPosition);
            }
        }

        internal interface Binder<D> where D : T
        {
            void Bind(D data);
        }
    }
}