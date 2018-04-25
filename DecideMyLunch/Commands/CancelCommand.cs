using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class CancelCommand : Command
    {
        private readonly ShopViewModel _vm;

        public CancelCommand(ShopViewModel vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            _vm.ViewCancelled();
        }
    }
}
