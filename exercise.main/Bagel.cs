using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Bagel : Item
    {

        public string Code { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Bagel(string code, float price, string variant)
        {
            Code = code;
            Price = price;
            Name = "Bagel";
            Variant = variant;
        }

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

        public double GetPrice() { return Price + GetFillingsPrice(); }

        public double GetFillingsPrice() { return 0; }
    }
}