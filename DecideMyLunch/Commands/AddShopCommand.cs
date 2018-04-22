using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.Models;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class AddShopCommand : ICommand
    {
        private AddShopViewModel _viewmodel;
        public AddShopCommand(AddShopViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public bool CanExecute (object parameter)
        {
            var item = parameter as Shop;
            //TODO: If any of the fields are empty then return false;
            return true;
        }

        public void Execute(object parameter)
        {
            var shop = parameter as Shop;
            _viewmodel.AddShop(shop);
        }

        public event EventHandler CanExecuteChanged;
    }
}
