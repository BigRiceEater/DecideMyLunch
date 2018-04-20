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
    public class SqlDataStore : IDataStore
    {
        public void InsertRestaurant(Restaurant item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Restaurant>();
                    var rows = conn.Insert(item);
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
    }
}
