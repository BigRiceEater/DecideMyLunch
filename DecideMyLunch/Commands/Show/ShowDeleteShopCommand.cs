using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Show
{
    public class ShowDeleteShopCommand : ShowCommand
    {
        public ShowDeleteShopCommand(MainViewModel vm) : base(vm) { }

        public override void Execute(object parameter)
        {
            _vm?.ShowDeleteShop();
        }
    }
}
