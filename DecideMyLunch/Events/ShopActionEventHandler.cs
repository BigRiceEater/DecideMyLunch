using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Enums;
using DecideMyLunch.Models;

namespace DecideMyLunch.Events
{

    // TODO: Don't have generic action event handler; 
    // introduces bug when the eventType is not checked. 
    // Safer to have individual events? but more work?

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
