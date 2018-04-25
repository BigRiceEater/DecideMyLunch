using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands
{
    public abstract class ShowCommand : Command
    {
        protected readonly MainViewModel _vm;
        public ShowCommand(MainViewModel vm)
        {
            _vm = vm;
        }
    }
}
