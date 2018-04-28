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
        public string ID { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            //BUG: can't enter space between two words. Check at insert instead.
            set => _name = value.Trim();
        }

        public bool Disabled { get; set; } = false;
    }
}
