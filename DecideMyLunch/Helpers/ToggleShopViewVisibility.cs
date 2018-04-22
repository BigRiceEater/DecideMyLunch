using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DecideMyLunch.Enums;
using DecideMyLunch.ViewModels;

namespace DecideMyLunch.Helpers
{
    public class ToggleShopViewVisibility
    {
        private Dictionary<EShopView,ShopViewModel> _viewModelsByView { get; set; }

        public ToggleShopViewVisibility(Dictionary<EShopView, ShopViewModel> viewmodels)
        {
            _viewModelsByView = viewmodels;
        }

        public void SetVisibility(EShopView view)
        {
            foreach (var item in _viewModelsByView)
            {
                item.Value.Visibility = item.Key.Equals(view) ? 
                    Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
