using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.Commands;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public class EditShopViewModel : ShopViewModel
    {

        public ICommand EditShopCommand { get; private set; }

        public EditShopViewModel(IDataStore dataStore) : base (dataStore)
        {
            EditShopCommand = new EditShopCommand(this);
        }

        public void UpdateShop(Restaurant shop)
        {
            throw new NotImplementedException();
        }
    }
}
