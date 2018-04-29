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
        [PrimaryKey]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public bool Disabled { get; set; } = false;
    }
}
