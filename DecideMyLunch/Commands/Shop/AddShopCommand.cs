using System;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
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
            var item = parameter as Models.Shop;
            return !String.IsNullOrWhiteSpace(item?.Name);
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Models.Shop;
            _viewmodel.AddShop(shop);
        }
    }
}
