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
    public class EditShopViewModel : ShopViewModel
    {
        #region Commands
        public ICommand EditShopCommand { get; private set; }
        #endregion

        #region Constructor
        public EditShopViewModel(IDataStore dataStore, UpdateAppStatusDelegate del) : 
            base (dataStore, del)
        {
            EditShopCommand = new EditShopCommand(this);
            _data.ShopActionEventHandler += OnShopActionEventHandler;
        }
        #endregion

        #region Event Handlers
        private void OnShopActionEventHandler(object sender, ShopActionEventArgs e)
        {
            if (e.EventType == EShopActionEvent.UpdatedShop)
                UpdateAppStatus($"Updated shop {e.Shop.Name}");
        }
        #endregion

        #region Command Callbacks
        public void UpdateShop(Shop shop)
        {
            _data.UpdateShop(shop);
        }
        #endregion
    }
}
