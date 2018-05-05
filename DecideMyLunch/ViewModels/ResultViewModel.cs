using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Abstract;
using DecideMyLunch.Events;
using DecideMyLunch.Helpers;
using DecideMyLunch.Interfaces;

namespace DecideMyLunch.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        #region Properties

        public ILunchAlgorithm RandomLunchAlgorithm { get; }

        private string _shopName;

        public string ShopName
        {
            get => _shopName ?? "Click decide!";
            set { _shopName = value; OnPropertyChanged(nameof(ShopName));}
        }
        #endregion

        #region Events
        public event ResultEventHandler ResultEvent; 
        #endregion

        #region Constructors
        public ResultViewModel(ILunchAlgorithm alg)
        {
            RandomLunchAlgorithm = alg;
        }
        #endregion

        #region Command Callbacks
        public async void DecideLunch()
        {
            //TODO: Animate each letter individually.
            await AnimateShopNameRandomAlphabet.AnimateResult(this);

            var shop = RandomLunchAlgorithm?.GetShop();
            ShopName = $"{shop?.Name}!";

            ResultEvent?.Invoke(this, null);

        }
        #endregion
    }
}
