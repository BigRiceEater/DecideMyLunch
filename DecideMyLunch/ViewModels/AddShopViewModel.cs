using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.Annotations;
using DecideMyLunch.Commands;
using DecideMyLunch.Commands.Shop;
using DecideMyLunch.Delegates;
using DecideMyLunch.Helpers;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public class AddShopViewModel : ShopViewModel
    {
        public AddShopCommand AddShopCommand { get; set; }

        private string _newShopName;

        public string NewShopName
        {
            get { return _newShopName; }
            set { _newShopName = value; OnPropertyChanged(nameof(NewShopName)); }
        }

        public AddShopViewModel(IDataStore dataStore, UpdateAppStatusDelegate del) : 
            base (dataStore, del)
        {
            AddShopCommand = new AddShopCommand(this);
            dataStore.DidInsertShopDelegate = new DidInsertShopDelegate(
                (item, pos) =>
                {
                    AddShopToList(item, pos);
                    UpdateAppStatus($"Added shop {item.Name}");
                });
        }

        public void AddShop(Shop item)
        {
            _data.InsertShop(item);
            SelectedShop = new Shop();
        }

        public override void ShowView()
        {
            base.ShowView();
            SelectedShop = new Shop();
        }
    }
}
