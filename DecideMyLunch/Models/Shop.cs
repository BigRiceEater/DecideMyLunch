using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DecideMyLunch.Models
{
    public class Shop
    {
        //TODO: Use Guid structure instead of string
        [PrimaryKey]
        public string ID { get; set; }

        public string Name { get; set; }

        public bool Disabled { get; set; } = false;
    }
}
