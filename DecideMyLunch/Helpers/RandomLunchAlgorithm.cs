using System;
using DecideMyLunch.Abstract;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.Helpers
{
    public class RandomLunchAlgorithm : LunchAlgorithm
    {
        private readonly IDataStore _dataService;
        private readonly Random _generator;
        public RandomLunchAlgorithm(IDataStore dataService) : base (dataService)
        {
            _dataService = dataService;
            _generator = new Random((int)System.DateTime.Now.Ticks);
        }
        public override Shop GetShop()
        {
            var shops = _dataService.GetAvailableShops();
            if (shops.Count < 1)
                return null;
            var index = _generator.Next(maxValue:shops.Count);
            return shops[index];
        }
    }
}
