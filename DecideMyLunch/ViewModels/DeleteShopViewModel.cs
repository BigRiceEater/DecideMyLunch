using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.Commands;
using DecideMyLunch.Commands.Shop;
using DecideMyLunch.Enums;
using DecideMyLunch.Events;
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
            _data.ShopActionEventHandler += OnShopActionEventHandler;
        }

        private void OnShopActionEventHandler(object sender, ShopActionEventArgs e)
        {
            if (e.EventType == EShopActionEvent.DeletedShop)
            {
                RemoveShopFromList(e.Shop);
                UpdateAppStatus($"Deleted shop {e.Shop.Name}");
            }
        }

        public void DeleteShop(Shop shop)
        {
            _data.DeleteShop(shop);
            SelectedShop = null;
        }
    }
}
