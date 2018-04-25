using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public class DeleteShopCommand : ShopCommand
    {

        public DeleteShopCommand(ShopViewModel vm) : base (vm) { }

        public override bool CanExecute(object parameter)
        {
            return parameter is Models.Shop;
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Models.Shop;
            (_vm as DeleteShopViewModel)?.DeleteShop(shop);
        }
    }
}
