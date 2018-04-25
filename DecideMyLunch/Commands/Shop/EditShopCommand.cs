using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public class EditShopCommand : Command
    {
        private EditShopViewModel _vm;

        public EditShopCommand(EditShopViewModel vm)
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
            _vm.UpdateShop(shop);
        }
    }
}
