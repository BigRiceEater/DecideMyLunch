using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Show
{
    public class ShowEditShopCommand : ShowCommand
    {
        public ShowEditShopCommand(MainViewModel vm) : base(vm) { }

        public override void Execute(object parameter)
        {
            _vm?.ShowEditShop();
        }
    }
}
