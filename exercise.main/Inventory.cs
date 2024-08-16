using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public static class Inventory
    {
        public static List<Item> Bagel { get; set; } = new List<Item>();
        public static List<Item> Coffee { get; set; } = new List<Item>();
        public static List<Item> Filling { get; set; } = new List<Item>();
    }
}