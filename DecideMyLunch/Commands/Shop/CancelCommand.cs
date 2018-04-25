using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public class CancelCommand : ShopCommand
    {
        public CancelCommand(ShopViewModel vm) : base(vm) { }

        public override void Execute(object parameter)
        {
            _vm.ViewCancelled();
        }
    }
}
