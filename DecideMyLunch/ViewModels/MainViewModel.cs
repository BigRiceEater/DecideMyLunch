using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DecideMyLunch.Annotations;
using DecideMyLunch.Commands;

namespace DecideMyLunch.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged(nameof(Result));}
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand DecideLunchCommand { get; set; }

        public MainViewModel()
        {
            DecideLunchCommand = new DecideLunchCommand(this);
            Result = "Nothing yet";
        }

        public void DecideLunch()
        {
            Result = "Yes!";
        }


    }
}
