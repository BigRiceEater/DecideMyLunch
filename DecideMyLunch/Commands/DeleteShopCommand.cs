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
    public class DeleteShopCommand : ICommand
    {
        private DeleteShopViewModel _vm;

        public DeleteShopCommand(DeleteShopViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            var shop = parameter as Shop;
            if (shop != null)
            {
                return !String.IsNullOrWhiteSpace(shop.Name);
            }
            else return false;
        }

        public void Execute(object parameter)
        {
            var shop = parameter as Shop;
            _vm?.DeleteShop(shop);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
