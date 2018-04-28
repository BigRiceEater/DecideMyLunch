using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecideMyLunch.Models;

namespace DecideMyLunch.Events
{

    public delegate void InsertShopEventHandler(object sender, InsertShopEventArgs e);

    public class InsertShopEventArgs : EventArgs
    {
        //C# 6.0 Auto Property with readonly backing field
        public Shop Shop { get; }
        public int InsertedAtIndex { get; }

        public InsertShopEventArgs(Shop shop, int index)
        {
            Shop = shop;
            InsertedAtIndex = index;
        }
    }
}
