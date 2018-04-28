using System;
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
        public void InsertShop(Shop item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {   
                    conn.CreateTable<Shop>();

                    var sameShop = conn.Table<Shop>().
                        FirstOrDefault(_ => _.Name.ToLower().Equals(item.Name.ToLower()));

                    if (sameShop != null)
                    {
                        //TODO: Bug adding same shop name
                        ShopActionErrorEventHandler?.Invoke(
                            this, new ShopActionErrorEventArgs(
                                item, EShopActionError.ShopNameAlreadyExist)
                            );
                    }
                    else
                    {
                        item.ID = this.GenerateGuid();
                        var rows = conn.Insert(item);
                        if (rows > 0)
                        {
                            var items = conn.Table<Shop>().OrderBy(
                                _ => _.Name, StringComparer.OrdinalIgnoreCase).ToList();
                            var pos = items.FindIndex(p => p.ID.Equals(item.ID));
                            InsertShopEventHandler?.Invoke(this, new InsertShopEventArgs(item, pos));
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
                    conn.Delete(item);
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
                    conn.Update(item);
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

        public event InsertShopEventHandler InsertShopEventHandler;
        public event ShopActionErrorEventHandler ShopActionErrorEventHandler;

        private string GenerateGuid()
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                string id = "undefined";
                try
                {
                    bool isGuidInvalid = true;
                    do {
                        id = Guid.NewGuid().ToString();
                        var matchedList = conn.Table<Shop>().Where(i => i.ID == id).ToList();
                        isGuidInvalid = matchedList.FirstOrDefault() != null;
                    } while (isGuidInvalid);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }

                return id;
            }
        }
    }
}
