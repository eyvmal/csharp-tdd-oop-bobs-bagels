using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Bagel : Item
    {

        public string Code { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public bool AddFilling(Filling filling)
        {
            return false;
        }

        public bool RemoveFilling(Filling filling)
        {
            return false;
        }

        public bool ChangeFilling(Filling oldFilling, Filling newFilling)
        {
            return false;
        }

        public double GetBagelPrice() { return Price; }

        public double GetFillingsPrice() { return 0; }
    }
}