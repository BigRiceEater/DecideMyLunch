using System;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.Helpers
{
    public class LunchAlgorithm
    {
        private IDataStore _dataService;
        private Random _generator;
        public LunchAlgorithm(IDataStore dataService)
        {
            _dataService = dataService;
            _generator = new Random((int)System.DateTime.Now.Ticks);
        }
        public Shop GetShop()
        {
            var shops = _dataService.GetAvailableShops();
            var index = _generator.Next(maxValue:shops.Count);
            return shops[index];
        }
    }
}
