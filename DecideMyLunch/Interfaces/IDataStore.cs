using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Models;

namespace DecideMyLunch.Interfaces
{
    public delegate void DidInsertRestaurant(Restaurant shop);

    public interface IDataStore
    {
        void InsertRestaurant(Restaurant item);
        void DeleteRestaurant(Restaurant item);
        void UpdateRestaurant(Restaurant item);

        List<Restaurant> GetRestaurants();
        DidInsertRestaurant DidInsertRestaurant { get; set; }
    }
}
