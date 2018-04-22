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
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public abstract class ShopViewModel : BaseViewModel
    {
        private Visibility _visibility;

        public Visibility Visibility
        {
            get { return _visibility; }
            set { _visibility = value; OnPropertyChanged(nameof(Visibility)); }
        }
        
        private Restaurant _selectedShop;
        public Restaurant SelectedShop
        {
            get => _selectedShop;
            set { _selectedShop = value; OnPropertyChanged(nameof(SelectedShop)); }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get => _cancelCommand;
            set { _cancelCommand = value; OnPropertyChanged(nameof(CancelCommand));}
        }

        protected IDataStore _data;
        public ShopViewModel(IDataStore dataStore, UpdateAppStatusDelegate del)
        {
            CancelCommand = new CancelCommand(this);
            UpdateAppStatus = del;
            _data = dataStore;
            SelectedShop = new Restaurant();
            Visibility = Visibility.Collapsed;
        }

        public void ViewCancelled()
        {
            Visibility = Visibility.Collapsed;
            SelectedShop = new Restaurant();
            UpdateAppStatus?.Invoke("Cancelled action");
        }
    }
}
