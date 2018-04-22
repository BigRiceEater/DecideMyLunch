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
        public Shop GetShop()
        {
            var shops = _dataService.GetShops();
            var index = _generator.Next(maxValue:shops.Count);
            return shops[index];
            //TODO: Check if shop is actually disabled before returning result.
        }
    }
}
