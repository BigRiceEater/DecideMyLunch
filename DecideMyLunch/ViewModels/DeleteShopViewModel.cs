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
    public class DeleteShopViewModel : ShopViewModel
    {
        public ICommand DeleteShopCommand { get; set; }

        public DeleteShopViewModel(IDataStore dataStore) : base (dataStore)
        {
            DeleteShopCommand = new DeleteShopCommand(this);
        }

        public void DeleteShop(Restaurant shop)
        {
            _data.DeleteRestaurant(shop);
        }
    }
}
