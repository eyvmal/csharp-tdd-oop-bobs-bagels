using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> Items { get; }

        public Basket()
        {
            Items = new List<Item>();
        }

        public bool AddItem(string name, string variant)
        {
            Item item = SelectItem(name, variant);

            if (item != null)
            {
                if (Items.Count() < BagelShop.Capacity)
                {
                    Items.Add(item);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveItem(string name, string variant)
        {
            Item item = SelectItem(name, variant);

            if (item != null)
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public float GetTotalCost()
        {

            float price = 0.0f;

            foreach (Item i in Items)
            {
                price += i.Price;
            }

            return price;
        }

        public Item SelectItem(string name, string variant)
        {
            return Inventory.Items.Where(i => i.Name.ToLower().Equals(name.ToLower()) && i.Variant.ToLower().Equals(variant.ToLower())).FirstOrDefault();
        }
    }
}