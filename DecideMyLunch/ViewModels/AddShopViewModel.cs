﻿using System;
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
    public class AddShopViewModel : ShopViewModel
    {
        public AddShopCommand AddShopCommand { get; set; }

        public AddShopViewModel(IDataStore dataStore) : base (dataStore)
        {
            AddShopCommand = new AddShopCommand(this);
        }

        public void AddShop(Restaurant item)
        {
            _data.InsertRestaurant(item);
        }
    }
}
