using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.Commands;
using DecideMyLunch.Commands.Shop;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public class DeleteShopViewModel : ShopViewModel
    {
        //TODO: Add DeleteAllShops Command
        //TODO: Event handler for deleted shop
        public ICommand DeleteShopCommand { get; set; }

        public DeleteShopViewModel(IDataStore dataStore, UpdateAppStatusDelegate del) : 
            base (dataStore, del)
        {
            DeleteShopCommand = new DeleteShopCommand(this);
        }

        public void DeleteShop(Shop shop)
        {
            _data.DeleteShop(shop);
            SelectedShop = null;
            RemoveShopFromList(shop);
            UpdateAppStatus($"Deleted shop {shop.Name}");
        }
    }
}
