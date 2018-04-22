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

    public class MainViewModel : BaseViewModel
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

        private EditShopViewModel _editShopViewModel;
        public EditShopViewModel EditShopViewModel
        {
            get => _editShopViewModel;
            set { _editShopViewModel = value; OnPropertyChanged(nameof(EditShopViewModel)); }
        }

        private DeleteShopViewModel _deleteShopViewModel;
        public DeleteShopViewModel DeleteShopViewModel
        {
            get => _deleteShopViewModel;
            set { _deleteShopViewModel = value; OnPropertyChanged(nameof(DeleteShopViewModel));}
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
            EditShopViewModel = new EditShopViewModel(data);
            DeleteShopViewModel = new DeleteShopViewModel(data);
        }

        public void DecideLunch()
        {
            Result = "Yes!";
        }

        public void ShowAddShop()
        {
            AddShopViewModel.Visibility = Visibility.Visible;
            EditShopViewModel.Visibility = Visibility.Collapsed;
            DeleteShopViewModel.Visibility = Visibility.Collapsed;
        }

        public void ShowEditShop()
        {
            AddShopViewModel.Visibility = Visibility.Collapsed;
            EditShopViewModel.Visibility = Visibility.Visible;
            DeleteShopViewModel.Visibility = Visibility.Collapsed;
        }

        public void ShowDeleteShop()
        {
            AddShopViewModel.Visibility = Visibility.Collapsed;
            EditShopViewModel.Visibility = Visibility.Collapsed;
            DeleteShopViewModel.Visibility = Visibility.Visible;
        }
    }
}
