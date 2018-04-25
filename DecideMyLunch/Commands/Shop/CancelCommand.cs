using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Shop
{
    public class CancelCommand : Command
    {
        private readonly ShopViewModel _vm;

        public CancelCommand(ShopViewModel vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            _vm.ViewCancelled();
        }
    }
}
