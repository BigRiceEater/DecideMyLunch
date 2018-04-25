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
    public class DeleteShopCommand : Command
    {
        private DeleteShopViewModel _vm;

        public DeleteShopCommand(DeleteShopViewModel vm)
        {
            _vm = vm;
        }

        public override bool CanExecute(object parameter)
        {
            var shop = parameter as Shop;
            return shop != null;
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Shop;
            _vm?.DeleteShop(shop);
        }
    }
}
