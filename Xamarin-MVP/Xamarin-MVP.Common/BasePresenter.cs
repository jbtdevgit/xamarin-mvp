using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_MVP.Common
{
    public abstract class BasePresenter : INotifyPropertyChanged
    {
        public IBaseView BaseView { get; set; }

        public BasePresenter(IBaseView baseView)
        {
            BaseView = baseView;
        }


        public abstract void Init();
        public abstract void Destroy();
        public abstract Task RestoreState(IList<string> savedStates);
        public abstract IList<string> SaveStates();


        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if(changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class BasePresenter<V> : BasePresenter where V : IBaseView
    {

        public BasePresenter(V view) : base(view)
        {
        }

        public new V BaseView
        {
            get
            {
                return (V)base.BaseView;
            }
            set
            {
                base.BaseView = value;
            }
        }
    }
}
