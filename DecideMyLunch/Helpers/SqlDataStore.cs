using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;
using SQLite;
namespace DecideMyLunch.Helpers
{
    // TODO: use GUID instead of relying on numbers?
    public class SqlDataStore : IDataStore
    {
        public void InsertRestaurant(Restaurant item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {   
                    //TODO: Check if shopname already exists
                    conn.CreateTable<Restaurant>();
                    item.ID = this.GenerateGuid();
                    var rows = conn.Insert(item);
                    if (rows > 0)
                    {
                        DidInsertRestaurant?.Invoke(item);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public void DeleteRestaurant(Restaurant item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Restaurant>();
                    conn.Delete(item);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public void UpdateRestaurant(Restaurant item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Restaurant>();
                    conn.Update(item);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public List<Restaurant> GetRestaurants()
        {
            //TODO: Order by A-Z
            var items = new List<Restaurant>();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Restaurant>();
                    items = conn.Table<Restaurant>().ToList();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return items;
        }

        public DidInsertRestaurant DidInsertRestaurant { get; set; }

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
                        var matchedList = conn.Table<Restaurant>().Where(i => i.ID == id).ToList();
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
