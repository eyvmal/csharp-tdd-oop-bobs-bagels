using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> Items { get; }
        public int Capacity { get; set; }

        public Basket()
        {
            Items = new List<Item>();
        }

        public bool AddItem(Item item)
        {
            return false;
        }

        public bool RemoveItem(Item item)
        {
            return false;
        }

        public double GetTotalCost() { return 0; }
    }
}