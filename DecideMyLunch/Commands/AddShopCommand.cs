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
            var item = parameter as string;
            if (item == null) return false;

            return !String.IsNullOrWhiteSpace(item);
        }

        public void Execute(object parameter)
        {
            var shopName = parameter as string;
            var shop = new Shop() {Name = shopName};
            _viewmodel.AddShop(shop);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
