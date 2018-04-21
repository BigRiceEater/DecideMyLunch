using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class ShowDeleteShopCommand : ICommand
    {
        private readonly MainViewModel _vm;

        public ShowDeleteShopCommand(MainViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm?.ShowDeleteShop();
        }

        public event EventHandler CanExecuteChanged;
    }
}
