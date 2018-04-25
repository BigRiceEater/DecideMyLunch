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
        }
        public Shop GetShop()
        {
            var shops = _dataService.GetShops();
            var index = _generator.Next(maxValue:shops.Count);
            return shops[index];
            //TODO: Check if shop is actually disabled before returning result.
        }
    }
}
