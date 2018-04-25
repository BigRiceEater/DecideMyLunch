using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Show
{
    public class ShowAddShopCommand : ShowCommand
    {
        public ShowAddShopCommand(MainViewModel vm) : base(vm) {}

        public override void Execute(object parameter)
        {
            _vm?.ShowAddShop();
        }
    }
}
