using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Helpers;

namespace DecideMyLunch.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        #region Properties
        //TODO: Interface for lunch algorithm
        public LunchAlgorithm LunchAlgorithm { get; }

        private string _shopName;

        public string ShopName
        {
            get => _shopName ?? "Click decide!";
            set { _shopName = value; OnPropertyChanged(nameof(ShopName));}
        }
        #endregion

        #region Constructors
        public ResultViewModel(LunchAlgorithm alg)
        {
            LunchAlgorithm = alg;
        }
        #endregion

        #region Command Callbacks
        public void DecideLunch()
        {
            //TODO: Animate decision with rolling letters.
            var shop = LunchAlgorithm?.GetShop();
            ShopName = $"{shop?.Name}!";
        }
        #endregion
    }
}
