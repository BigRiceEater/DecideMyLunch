using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Interfaces;
using DecideMyLunch.Models;

namespace DecideMyLunch.Abstract
{
    public abstract class LunchAlgorithm : ILunchAlgorithm
    {
        private IDataStore DataStore { get; }

        public LunchAlgorithm(IDataStore dataStore)
        {
            DataStore = dataStore;
        }

        public abstract Shop GetShop();
    }
}
