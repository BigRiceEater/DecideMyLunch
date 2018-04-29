using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DecideMyLunch.Annotations;
using DecideMyLunch.Commands;
using DecideMyLunch.Commands.Shop;
using DecideMyLunch.Enums;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public abstract class ShopViewModel : BaseViewModel
    {
        private Visibility _visibility;

        public Visibility Visibility
        {
            get { return _visibility; }
            set { _visibility = value; OnPropertyChanged(nameof(Visibility)); }
        }
        
        private Shop _selectedShop;
        public Shop SelectedShop
        {
            get => _selectedShop;
            set
            {
                _selectedShop = value;
                OnPropertyChanged(nameof(SelectedShop));
            }
        }

        private static ObservableCollection<Shop> _shops;
        public ObservableCollection<Shop> Shops
        {
            get => _shops;
            set
            {
                //TODO: can we use ?? null coalescing
                if (_shops == null)
                {
                    _shops = value;
                }
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get => _cancelCommand;
            set { _cancelCommand = value; OnPropertyChanged(nameof(CancelCommand));}
        }

        protected IDataStore _data;
        public ShopViewModel(IDataStore dataStore, UpdateAppStatusDelegate del)
        {
            CancelCommand = new CancelCommand(this);
            UpdateAppStatus = del;
            _data = dataStore;
            SelectedShop = new Shop();
            Visibility = Visibility.Collapsed;
            InitShops();
        }

        private void InitShops()
        {
            Shops = new ObservableCollection<Shop>(_data.GetAllShops());
        }

        public void ViewCancelled()
        {
            Visibility = Visibility.Collapsed;
            SelectedShop = null;
            UpdateAppStatus?.Invoke("Cancelled action");
        }

        protected void AddShopToList(Shop shop, int pos)
        {
            Shops.Insert(pos,shop);
        }

        protected void RemoveShopFromList(Shop shop)
        {
            var success = Shops.Remove(shop);
        }

        public virtual void ShowView()
        {
            Visibility = Visibility.Visible;
            SelectedShop = null;
        }
    }
}
