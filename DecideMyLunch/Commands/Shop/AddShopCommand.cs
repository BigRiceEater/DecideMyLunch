using System;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public class AddShopCommand : ShopCommand
    {
        public AddShopCommand(ShopViewModel vm) : base(vm) { }

        public override bool CanExecute (object parameter)
        {
            var item = parameter as Models.Shop;
            //TODO: using static System.String;
            return !String.IsNullOrWhiteSpace(item?.Name);
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Models.Shop;
            (_vm as AddShopViewModel)?.AddShop(shop);
        }
    }
}
