<<<<<<< HEAD
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> parent of e85a591 (c1)
namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {
<<<<<<< HEAD
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public KioskProduct(string name, decimal price, string description = "")
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public KioskProduct() { }

        public override string ToString()
        {
            return $"{Name} - €{Price} | {Description}";
        }
=======

        public string Name { get; set; }

>>>>>>> parent of e85a591 (c1)
    }
}
