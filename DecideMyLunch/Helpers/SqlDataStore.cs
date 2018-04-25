using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Delegates;
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
                    //TODO: Check if shopname already exists
                    conn.CreateTable<Shop>();
                    item.ID = this.GenerateGuid();
                    var rows = conn.Insert(item);
                    if (rows > 0)
                    {
                        DidInsertShopDelegate?.Invoke(item);
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
            //TODO: Order by A-Z
            var items = new List<Shop>();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Shop>();
                    items = conn.Table<Shop>().ToList();
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

        public DidInsertShopDelegate DidInsertShopDelegate { get; set; }

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
