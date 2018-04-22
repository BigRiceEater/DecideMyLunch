using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Delegates;
using DecideMyLunch.Models;

namespace DecideMyLunch.Interfaces
{
    public interface IDataStore
    {
        void InsertRestaurant(Restaurant item);
        void DeleteRestaurant(Restaurant item);
        void UpdateRestaurant(Restaurant item);

        List<Restaurant> GetRestaurants();
        DidInsertRestaurant DidInsertRestaurant { get; set; }
    }
}
