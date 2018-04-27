using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Enums;
using DecideMyLunch.Models;

namespace DecideMyLunch.Events
{
    public delegate void ShopActionErrorEventHandler(object sender, ShopActionErrorEventArgs e);
    public class ShopActionErrorEventArgs : EventArgs
    {
        // this is a readonly auto-property from C# 6.0
        public Shop Shop { get; }
        public EShopActionError Error { get; }

        public ShopActionErrorEventArgs(Shop shop, EShopActionError error)
        {
            Shop = shop;
            Error = error;
        }
    }
}
