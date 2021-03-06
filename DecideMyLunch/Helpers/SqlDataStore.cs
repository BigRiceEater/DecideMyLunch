﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Enums;
using DecideMyLunch.Events;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;
using SQLite;
namespace DecideMyLunch.Helpers
{
    public class SqlDataStore : IDataStore
    {
        #region CRUD Methods
        public void InsertShop(Shop item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {   
                    conn.CreateTable<Shop>();

                    item.Name = item.Name.Trim();
                    item.Guid = this.GenerateGuid();

                    var sameShop = conn.Table<Shop>().
                        FirstOrDefault(_ => _.Name.ToLower().Equals(item.Name.ToLower()));

                    if (sameShop != null)
                    {
                        ShopActionErrorEventHandler?.Invoke(
                            this, new ShopActionErrorEventArgs(
                                item, EShopActionError.ShopNameAlreadyExist)
                            );
                    }
                    else
                    {
                        var rows = conn.Insert(item);
                        if (rows > 0)
                        {
                            var items = conn.Table<Shop>().OrderBy(
                                _ => _.Name, StringComparer.OrdinalIgnoreCase).ToList();
                            var pos = items.FindIndex(p => p.Guid.Equals(item.Guid));
                            ShopActionEventHandler?.Invoke(this, 
                                new ShopActionEventArgs(EShopActionEvent.InsertedShop, item, pos));
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public void DeleteShop(Shop item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Shop>();
                    var rows = conn.Delete(item);

                    if (rows > 0)
                    {
                        ShopActionEventHandler?.Invoke(this, 
                            new ShopActionEventArgs(EShopActionEvent.DeletedShop, item));
                    }
                    //TODO: event handler for exception and when rows less than zero
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public void UpdateShop(Shop item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Shop>();
                    var rows = conn.Update(item);

                    if (rows > 0)
                    {
                        ShopActionEventHandler?.Invoke(this,
                            new ShopActionEventArgs(EShopActionEvent.UpdatedShop, item));
                    }
                    //TODO: Exception ShopErrorEventHandler

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public List<Shop> GetAllShops()
        {
            var items = new List<Shop>();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Shop>();
                    items = conn.Table<Shop>().OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase).ToList();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return items;
        }

        public List<Shop> GetAvailableShops()
        {
            var items = new List<Shop>();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    items = conn.Table<Shop>().Where(p => !p.Disabled).ToList();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return items;
        }
        #endregion

        #region Events
        public event ShopActionEventHandler ShopActionEventHandler;
        public event ShopActionErrorEventHandler ShopActionErrorEventHandler;
        #endregion

        #region Methods
        private Guid GenerateGuid()
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                Guid guid = Guid.Empty;
                try
                {
                    bool isGuidInvalid = true;
                    do
                    {
                        guid = Guid.NewGuid();
                        var matchedList = conn.Table<Shop>().Where(i => i.Guid == guid).ToList();
                        isGuidInvalid = matchedList.FirstOrDefault() != null;
                    } while (isGuidInvalid);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

                return guid;
            }
        }
        #endregion 
    }
}
