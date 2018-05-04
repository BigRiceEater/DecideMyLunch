using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Abstract;
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

        #region Constructors
        public ResultViewModel(ILunchAlgorithm alg)
        {
            RandomLunchAlgorithm = alg;
        }
        #endregion

        #region Command Callbacks
        public async void DecideLunch()
        {
            var r = new Random((int)System.DateTime.Today.Ticks);
            await Task.Run(async () => {

                var log = 1f;
                var it = r.Next(30, 40);
                for (int cycles = 0; cycles < it; ++cycles)
                {
                    ShopName = AnimateShopNameRandomAlphabet.GetName(r.Next(5, 10));

                    if (cycles == it - 1)
                        await Task.Delay(1250);
                    else
                        await Task.Delay((int)(cycles * cycles * 0.5) + r.Next(0, 10));
                }
                var shop = RandomLunchAlgorithm?.GetShop();
                ShopName = $"{shop?.Name}!";
            });

            //TODO: Animate each letter individually.

        }
        #endregion
    }
}
