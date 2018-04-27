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
        //TODO: Convert to auto property C# 6.0
        private readonly Shop shop;
        private readonly int insertedAtIndex;

        public InsertShopEventArgs(Shop shop, int index)
        {
            this.shop = shop;
            this.insertedAtIndex = index;
        }

        public Shop Item
        {
            get => shop;
        }

        public int InsertedAtIndex
        {
            get => insertedAtIndex;
        }

    }
}
