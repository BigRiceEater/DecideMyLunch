using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public class EditShopCommand : ShopCommand
    {
        public EditShopCommand(ShopViewModel vm) : base (vm) { }
        public override bool CanExecute(object parameter)
        {
            return parameter is Models.Shop;
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Models.Shop;
            (_vm as EditShopViewModel)?.UpdateShop(shop);
        }
    }
}
