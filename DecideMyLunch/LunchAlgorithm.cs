using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch
{
    //TODO: Move LunchAlgorithm to Helper folder
    public class LunchAlgorithm
    {
        private IDataStore _dataService;
        private Random _generator;
        public LunchAlgorithm(IDataStore dataService)
        {
            _dataService = dataService;
        }
        public Restaurant GetRestaurant()
        {
            var restaurants = _dataService.GetRestaurants();
            var index = _generator.Next(maxValue:restaurants.Count);
            return restaurants[index];
            //TODO: Check if restaurant is actually disabled before returning result.
        }
    }
}
