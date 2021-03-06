﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Events;
using DecideMyLunch.Models;

namespace DecideMyLunch.Interfaces
{
    public interface IDataStore
    {
        void InsertShop(Shop item);
        void DeleteShop(Shop item);
        void UpdateShop(Shop item);

        List<Shop> GetAllShops();
        List<Shop> GetAvailableShops();

        //TODO: Remove Handler from property name
        event ShopActionEventHandler ShopActionEventHandler;
        event ShopActionErrorEventHandler ShopActionErrorEventHandler;
    }
}
