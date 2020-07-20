using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Xamarin_MVP.Ioc.Modules
{
    public class ModuleCatalogBase : IModuleCatalog
    {
        private ModuleCatalogItemCollection _Collection { get; }
        public virtual IEnumerable<IModuleInfo> Modules => GrouplessModules.Union(Groups.SelectMany(g => g));
        public IEnumerable<IModuleInfoGroup> Groups => Collection.OfType<IModuleInfoGroup>();
        protected IEnumerable<IModuleInfo> GrouplessModules => Collection.OfType<IModuleInfo>();
        public Collection<IModuleCatalogItem> Collection => _Collection;
        protected bool Validated { get; set; }
        private bool IsLoaded;

        public ModuleCatalogBase()
        {
            _Collection = new ModuleCatalogItemCollection();
            _Collection.CollectionChanged += CollectionChanged;
        }

        public ModuleCatalogBase(IEnumerable<IModuleInfo> modules) : this ()
        {
            if (modules == null) throw new Exception();

            foreach(IModuleInfo module in modules)
            {
                Collection.Add(module);
            }
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Validated)
            {
                EnsureIfCatalogIsValidated();
            }
        }

        protected virtual void EnsureIfCatalogIsValidated()
        {
            if (!Validated)
            {
                ValidateCatalog();
            }
        }

        public virtual void ValidateCatalog()
        {
            ValidateUniqueModules();

            Validated = true;
        }

        protected virtual void ValidateUniqueModules()
        {
            List<string> moduleNames = Modules.Select(x => x.Name).ToList();

            string duplicateModules = moduleNames.FirstOrDefault(x => moduleNames.Count(y => y.Equals(x)) > 1);

            if(duplicateModules != null)
            {
                throw new Exception();
            }
        }

        public IModuleCatalog AddModule(IModuleInfo moduleInfo)
        {
            Collection.Add(moduleInfo);
            return this;
        }

        public void Initialize()
        {
            if (!IsLoaded)
            {
                LoadCatalog();
            }

            ValidateCatalog();
        }

        public virtual void LoadCatalog()
        {
            IsLoaded = true;
        }

        private class ModuleCatalogItemCollection : Collection<IModuleCatalogItem>, INotifyCollectionChanged
        {
            public event NotifyCollectionChangedEventHandler CollectionChanged;

            protected override void InsertItem(int index, IModuleCatalogItem item)
            {
                base.InsertItem(index, item);

                RaiseCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, index));
            }

            protected void RaiseCollectionChanged(NotifyCollectionChangedEventArgs eventHandler)
            {
                CollectionChanged?.Invoke(this, eventHandler);
            }
        }
    }
}
