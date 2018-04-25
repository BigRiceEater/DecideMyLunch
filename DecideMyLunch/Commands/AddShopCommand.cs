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
    public class AddShopCommand : Command
    {
        private AddShopViewModel _viewmodel;
        public AddShopCommand(AddShopViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public override bool CanExecute (object parameter)
        {
            var item = parameter as Shop;
            return !String.IsNullOrWhiteSpace(item?.Name);
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Shop;
            _viewmodel.AddShop(shop);
        }
    }
}
