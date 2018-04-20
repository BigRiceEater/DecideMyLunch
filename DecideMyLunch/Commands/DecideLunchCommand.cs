using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public class DecideLunchCommand : ICommand
    {
        public MainViewModel MainViewModel { get; set; }

        public DecideLunchCommand(MainViewModel viewModel)
        {
            MainViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.DecideLunch();
        }

        public event EventHandler CanExecuteChanged;
    }
}
