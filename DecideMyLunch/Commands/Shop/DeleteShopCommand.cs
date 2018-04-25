using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
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
            var shop = parameter as Models.Shop;
            return shop != null;
        }

        public override void Execute(object parameter)
        {
            var shop = parameter as Models.Shop;
            _vm?.DeleteShop(shop);
        }
    }
}
