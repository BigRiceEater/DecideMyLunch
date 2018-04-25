using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Commands.Show
{
    public abstract class ShowCommand : Command
    {
        protected readonly MainViewModel _vm;
        public ShowCommand(MainViewModel vm)
        {
            _vm = vm;
        }
    }
}
