using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch
{
    public class LunchAlgorithm
    {
        private static IDataStore _dataService;
        private static Random _generator;
        public LunchAlgorithm(IDataStore dataService)
        {
            _dataService = dataService;
        }
        public static Restaurant GetRestaurant()
        {
            var restaurants = _dataService.GetRestaurants();
            var index = _generator.Next(maxValue:restaurants.Count);
            return restaurants[index];
        }
    }
}
