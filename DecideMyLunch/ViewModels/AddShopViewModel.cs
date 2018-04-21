using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Annotations;
using DecideMyLunch.Commands;
using DecideMyLunch.Helpers;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public class AddShopViewModel : INotifyPropertyChanged
    {

        private Restaurant _shop;
        public Restaurant Shop
        {
            get { return _shop; }
            set { _shop = value; OnPropertyChanged(nameof(Shop)); }
        }

        public AddShopCommand AddShopCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private IDataStore _data;

        //private DidInsertRestaurant _didInsertRestaurant;

        //public DidInsertRestaurant DidInsertRestaurant
        //{
        //    get { return _didInsertRestaurant; }
        //    set
        //    {
        //        if (_data != null)
        //        {
        //            _data.DidInsertRestaurant = value;
        //        }
        //    }
        //}

        public AddShopViewModel(IDataStore dataStore)
        {
            Shop = new Restaurant();

            _data = dataStore;

            AddShopCommand = new AddShopCommand(this);
        }

        public void AddShop(Restaurant item)
        {
            _data.InsertRestaurant(item);
        }
    }
}
