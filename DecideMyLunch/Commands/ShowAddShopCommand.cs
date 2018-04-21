using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class ShowAddShopCommand : ICommand
    {
        private MainViewModel _viewModel;

        public ShowAddShopCommand(MainViewModel vm)
        {
            _viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel?.ShowAddShop();
        }

        public event EventHandler CanExecuteChanged;
    }
}
