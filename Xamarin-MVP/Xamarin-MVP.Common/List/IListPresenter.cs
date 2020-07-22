using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_MVP.Common.List
{
    public interface IListPresenter
    {
        Task GetCollectionOfStores();
    }
}
