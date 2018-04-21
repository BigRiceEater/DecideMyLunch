using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DecideMyLunch.Annotations;
using DecideMyLunch.Commands;
using DecideMyLunch.Helpers;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    //TODO: Add update button
    //TODO: Add delete button
    //TODO: Make disable button actually work

    public class MainViewModel : INotifyPropertyChanged
    {

        private string _result;
        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(nameof(Result));}
        }

        private string _applicationStatus;
        public string ApplicationStatus
        {
            get => _applicationStatus;
            set { _applicationStatus = value; OnPropertyChanged(nameof(ApplicationStatus)); }
        }

        private AddShopViewModel _addShopViewModel;
        public AddShopViewModel AddShopViewModel
        {
            get => _addShopViewModel;
            set
            {
                _addShopViewModel = value; OnPropertyChanged(nameof(AddShopViewModel));
            }
        }

        private Visibility _addShopViewVisibility;
        public Visibility AddShopViewVisibility
        {
            get => _addShopViewVisibility;
            set { _addShopViewVisibility = value; OnPropertyChanged(nameof(AddShopViewVisibility)); }
        }

        private EditShopViewModel _editShopViewModel;
        public EditShopViewModel EditShopViewModel
        {
            get => _editShopViewModel;
            set { _editShopViewModel = value; OnPropertyChanged(nameof(EditShopViewModel)); }
        }

        private Visibility _editShopViewVisibility;
        public Visibility EditShopViewVisibility
        {
            get => _editShopViewVisibility;
            set { _editShopViewVisibility = value; OnPropertyChanged(nameof(EditShopViewVisibility));}
        }

        private DeleteShopViewModel _deleteShopViewModel;
        public DeleteShopViewModel DeleteShopViewModel
        {
            get => _deleteShopViewModel;
            set { _deleteShopViewModel = value; OnPropertyChanged(nameof(DeleteShopViewModel));}
        }

        private Visibility _deleteShopViewVisibility;
        public Visibility DeleteShopViewVisibility
        {
            get => _deleteShopViewVisibility;
            set { _deleteShopViewVisibility = value; OnPropertyChanged(nameof(DeleteShopViewVisibility)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand DecideLunchCommand { get; set; }
        public ICommand ShowAddShopCommand { get; set; }
        public ICommand ShowEditShopCommand { get; set; }
        public ICommand ShowDeleteShopCommand { get; set; }

        private LunchAlgorithm _lunchAlgorithm;

        public MainViewModel()
        {
            DecideLunchCommand = new DecideLunchCommand(this);
            ShowAddShopCommand = new ShowAddShopCommand(this);
            ShowEditShopCommand = new ShowEditShopCommand(this);
            ShowDeleteShopCommand = new ShowDeleteShopCommand(this);

            Result = "Nothing yet";
            ApplicationStatus = "Ready";

            IDataStore data = new SqlDataStore
            {
                DidInsertRestaurant = new DidInsertRestaurant(item =>
                    {
                        ApplicationStatus = String.Format("Successfully added {0}", item.Name);
                    }
                )};

            _lunchAlgorithm = new LunchAlgorithm(data);

            AddShopViewModel = new AddShopViewModel(data);
            AddShopViewVisibility = Visibility.Collapsed;

            EditShopViewModel = new EditShopViewModel(data);
            EditShopViewVisibility = Visibility.Collapsed;

            DeleteShopViewModel = new DeleteShopViewModel(data);
            DeleteShopViewVisibility = Visibility.Collapsed;
        }

        public void DecideLunch()
        {
            Result = "Yes!";
        }

        public void ShowAddShop()
        {
            AddShopViewVisibility = Visibility.Visible;
            EditShopViewVisibility = Visibility.Collapsed;
            DeleteShopViewVisibility = Visibility.Collapsed;
        }

        public void ShowEditShop()
        {
            AddShopViewVisibility = Visibility.Collapsed;
            EditShopViewVisibility = Visibility.Visible;
            DeleteShopViewVisibility = Visibility.Collapsed;
        }

        public void ShowDeleteShop()
        {
            AddShopViewVisibility = Visibility.Collapsed;
            EditShopViewVisibility = Visibility.Collapsed;
            DeleteShopViewVisibility = Visibility.Visible;
        }
    }
}
