using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public abstract class ShopCommand : Command
    {
        protected readonly ShopViewModel _vm;
        protected ShopCommand(ShopViewModel vm)
        {
            _vm = vm;
        }
    }
}
