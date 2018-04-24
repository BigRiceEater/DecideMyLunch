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
    public class EditShopCommand : ICommand
    {
        private EditShopViewModel _vm;

        public EditShopCommand(EditShopViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            var shop = parameter as Shop;
            return shop != null;
        }

        public void Execute(object parameter)
        {
            var shop = parameter as Shop;
            _vm.UpdateShop(shop);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
