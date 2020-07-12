using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin_MVP.Common.IViews;

namespace Xamarin_MVP.Common.Presenter
{
    public abstract class BasePresenter : INotifyPropertyChanged
    {
        public IBaseView IBaseView { get; set; }

        public BasePresenter(IBaseView ibaseView)
        {
            IBaseView = ibaseView;
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
}
