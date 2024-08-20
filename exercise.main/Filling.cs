﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Filling : Item
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Filling(string code, decimal price, string variant)
        {
            Code = code;
            Price = price;
            Name = "Filling";
            Variant = variant;
        }
    }
}