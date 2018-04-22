using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class CancelCommand : ICommand
    {
        private readonly ShopViewModel _vm;

        public CancelCommand(ShopViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.ViewCancelled();
        }

        public event EventHandler CanExecuteChanged;
    }
}
