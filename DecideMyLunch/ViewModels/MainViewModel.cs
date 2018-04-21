﻿using System;
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
    //BUG: Select shop, change name, add shop -> changes record, not new entry.
    //TODO: Add update button
    //TODO: Add delete button
    //TODO: Make disable button actually work

    public class MainViewModel : INotifyPropertyChanged
    {
        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged(nameof(Result));}
        }

        private Restaurant _selectedRestaurant;

        public Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set { _selectedRestaurant = value; OnPropertyChanged(nameof(SelectedRestaurant)); }
        }

        public List<Restaurant> Restaurants
        {
            get { return _handler.Items; }
        }

        public class RestaurantHandler
        {
            public RestaurantHandler()
            {
                Items = new List<Restaurant>();
            }

            public List<Restaurant> Items { get; private set; }

            public void Add(Restaurant item)
            {
                Items.Add(item);
            }
        }

        private RestaurantHandler _handler;

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand DecideLunchCommand { get; set; }
        public ICommand AddShopCommand { get; set; }
        private readonly IDataStore _data;
        private LunchAlgorithm _lunchAlgorithm;


        public MainViewModel()
        {
            DecideLunchCommand = new DecideLunchCommand(this);
            AddShopCommand = new AddShopCommand(this);
            Result = "Nothing yet";
            SelectedRestaurant = new Restaurant(); //TODO: Default disable to true in new object
            _data = new SqlDataStore();
            _lunchAlgorithm = new LunchAlgorithm(_data);
            //TODO: Remove handler to use observable collection
            _handler = new RestaurantHandler();

            foreach (var item in _data.GetRestaurants())
            {
                _handler.Add(item);
            }

            //Restaurants = new ObservableCollection<Restaurant>(_data.GetRestaurants());
        }

        public void DecideLunch()
        {
            Result = "Yes!";
            
        }

        public void AddShop(Restaurant item)
        {
            _data.InsertRestaurant(item);
        }


    }
}
