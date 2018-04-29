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
using DecideMyLunch.Commands.Show;
using DecideMyLunch.Events;
using DecideMyLunch.Enums;
using DecideMyLunch.Helpers;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    //TODO: Add button 'Show disabled shops'
    //TODO: Add label 'Num of disabled shops'

    public class MainViewModel : BaseViewModel
    {
        private string _applicationStatus;
        public string ApplicationStatus
        {
            get => _applicationStatus;
            set { _applicationStatus = value; OnPropertyChanged(nameof(ApplicationStatus)); }
        }

        private string _totalNumShops;

        public string TotalNumShops
        {
            get => $"Number of shops: {_totalNumShops}";
            set { _totalNumShops = value; OnPropertyChanged(nameof(TotalNumShops));}
        }

        //TODO: Add code regions 

        private ResultViewModel _resultViewModel;

        public ResultViewModel ResultViewModel
        {
            get => _resultViewModel;
            set { _resultViewModel = value; OnPropertyChanged(nameof(ResultViewModel));}
        }


        private AddShopViewModel _addShopViewModel;
        public AddShopViewModel AddShopViewModel
        {
            get => _addShopViewModel;
            set { _addShopViewModel = value; OnPropertyChanged(nameof(AddShopViewModel)); }
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

        private readonly IDataStore _data;
        private readonly ToggleShopViewVisibility _visibilityToggler;

        public MainViewModel() 
        {
            DecideLunchCommand = new DecideLunchCommand(this);
            ShowAddShopCommand = new ShowAddShopCommand(this);
            ShowEditShopCommand = new ShowEditShopCommand(this);
            ShowDeleteShopCommand = new ShowDeleteShopCommand(this);

            _data = new SqlDataStore();

            // TODO: UpdateAppStatus into event ?
            UpdateAppStatus = new UpdateAppStatusDelegate((msg) =>
            {
                ApplicationStatus = msg;
                UpdateStatistics();
            });

            ResultViewModel = new ResultViewModel(new LunchAlgorithm(_data));

            AddShopViewModel = new AddShopViewModel(_data, UpdateAppStatus);
            EditShopViewModel = new EditShopViewModel(_data, UpdateAppStatus);
            DeleteShopViewModel = new DeleteShopViewModel(_data, UpdateAppStatus);

            _visibilityToggler = new ToggleShopViewVisibility(
                new Dictionary<EShopView, ShopViewModel>()
                {
                    {EShopView.Add, AddShopViewModel},
                    {EShopView.Edit, EditShopViewModel},
                    {EShopView.Delete, DeleteShopViewModel}
                });
         
            UpdateStatistics();
            ApplicationStatus = "Ready";

        }

        private void UpdateStatistics()
        {
            TotalNumShops = _data?.GetAllShops().Count.ToString();
        }

        public void DecideLunch()
        {
            ResultViewModel.DecideLunch();
            UpdateAppStatus("Lunch decided!");
        }

        public void ShowAddShop()
        {
            _visibilityToggler.SetVisibility(EShopView.Add);
            UpdateAppStatus("Showing add shop section");
        }

        public void ShowEditShop()
        {
            _visibilityToggler.SetVisibility(EShopView.Edit);
            UpdateAppStatus("Showing edit shop section");
        }

        public void ShowDeleteShop()
        {
            _visibilityToggler.SetVisibility(EShopView.Delete);
            UpdateAppStatus("Showing delete shop section");
        }
    }
}
