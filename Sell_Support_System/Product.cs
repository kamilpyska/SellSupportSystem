using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sell_Support_System
{
    class Product
    {
        public Bitmap image { get; set; }
        public string name { get; set; }
        public double prize { get; set; }

        public Product(Bitmap image_, string name_, double prize_)
        {
            image = image_;
            name = name_;
            prize = prize_;
        }
    }
}
