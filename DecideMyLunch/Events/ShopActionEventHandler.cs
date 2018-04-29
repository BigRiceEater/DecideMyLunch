using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Enums;
using DecideMyLunch.Models;

namespace DecideMyLunch.Events
{

    public delegate void ShopActionEventHandler(object sender, ShopActionEventArgs e);

    public class ShopActionEventArgs : EventArgs
    {
        //C# 6.0 Auto Property with readonly backing field
        public Shop Shop { get; }
        public int? Index { get; }
        public EShopActionEvent EventType { get; }

        public ShopActionEventArgs(EShopActionEvent eventType, Shop shop, int? index = null)
        {
            EventType = eventType;
            Shop = shop;
            Index = index;
        }
    }
}
