using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class DecideLunchCommand : Command
    {
        private readonly MainViewModel _vm;
        //TODO: Move to Command abstract class and modify base CanExecute to use IsBusy
        public bool IsBusy { get; set; } = false;

        public DecideLunchCommand(MainViewModel viewModel)
        {
            _vm = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return ! IsBusy;
        }

        public override void Execute(object parameter)
        {
            _vm.DecideLunch();
        }
    }
}
