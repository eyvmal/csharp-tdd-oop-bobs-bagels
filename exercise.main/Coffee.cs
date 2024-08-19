using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Coffee : Item
    {
        public string Code { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Coffee(string code, float price, string variant)
        {
            Code = code;
            Price = price;
            Name = "Coffee";
            Variant = variant;
        }
    }
}