﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DecideMyLunch.Annotations;
using DecideMyLunch.Commands;
using DecideMyLunch.Commands.Shop;
using DecideMyLunch.Enums;
using DecideMyLunch.Events;
using DecideMyLunch.Helpers;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.ViewModels
{
    public class AddShopViewModel : ShopViewModel
    {
        #region Commands
        public AddShopCommand AddShopCommand { get; set; }
        #endregion

        #region Constructors
        public AddShopViewModel(IDataStore dataStore, UpdateAppStatusDelegate del) : 
            base (dataStore, del)
        {
            AddShopCommand = new AddShopCommand(this);
            _data.ShopActionEventHandler += OnShopActionEventHandler;
            _data.ShopActionErrorEventHandler += OnShopActionErrorEventHandler;
        }
        #endregion

        #region Event Handlers
        private void OnShopActionErrorEventHandler(object sender, ShopActionErrorEventArgs e)
        {
            if(e.Error == EShopActionError.ShopNameAlreadyExist)
                UpdateAppStatus($"Shop {e.Shop.Name} already exists!");
        }

        private void OnShopActionEventHandler(object sender, ShopActionEventArgs e)
        {
            if (e.EventType == EShopActionEvent.InsertedShop)
            {
                AddShopToList(e.Shop, e.Index.GetValueOrDefault());
                UpdateAppStatus($"Added shop {e.Shop.Name}");
            }
        }
        #endregion 

        #region Command Callbacks
        public void AddShop(Shop item)
        {
            _data.InsertShop(item);
            SelectedShop = new Shop();
        }

        public override void ShowView()
        {
            base.ShowView();
            SelectedShop = new Shop();
        }

        #endregion 
    }
}
