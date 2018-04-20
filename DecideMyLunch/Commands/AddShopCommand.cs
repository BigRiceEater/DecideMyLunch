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
        private MainViewModel _viewmodel;
        public AddShopCommand(MainViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public bool CanExecute (object parameter)
        {
            var item = parameter as Restaurant;
            //TODO: If any of the fields are empty then return false;
            return true;
        }

        public void Execute(object parameter)
        {
            var item = parameter as Restaurant;
            _viewmodel.AddShop(item);
        }

        public event EventHandler CanExecuteChanged;
    }
}
