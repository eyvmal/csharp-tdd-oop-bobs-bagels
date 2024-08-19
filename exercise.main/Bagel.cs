using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace exercise.main
{
    public class Bagel : Item
    {

        public string Code { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public List<Item> Fillings { get; set; }

        public Bagel(string code, float price, string variant)
        {
            Code = code;
            Price = price;
            Name = "Bagel";
            Variant = variant;
            Fillings = new List<Item>();
        }

        public bool AddFilling(string variant)
        {
            Item item = Inventory.Items.Where(i => i.Name.ToLower().Equals("filling") && i.Variant.ToLower().Equals(variant.ToLower())).FirstOrDefault();

            if (item != null)
            {
                Fillings.Add(item);
                return true;
            }
            return false;
        }

        public bool RemoveFilling(string variant)
        {
            Item item = Inventory.Items.Where(i => i.Name.ToLower().Equals("filling") && i.Variant.ToLower().Equals(variant.ToLower())).FirstOrDefault();

            if (item != null)
            {
                Fillings.Remove(item);
                return true;
            }
            return false;
        }

        public bool ChangeFilling(string oldFilling, string newFilling)
        {
            Item oldFill = Inventory.Items.Where(i => i.Name.ToLower().Equals("filling") && i.Variant.ToLower().Equals(oldFilling.ToLower())).FirstOrDefault();
            Item newFill = Inventory.Items.Where(i => i.Name.ToLower().Equals("filling") && i.Variant.ToLower().Equals(newFilling.ToLower())).FirstOrDefault();

            if (oldFill != null && newFill != null)
            {
                Fillings.Remove(oldFill);
                Fillings.Add(newFill);
                return true;
            }
            return false;
        }

        public float GetPrice() { return Price + GetFillingsPrice(); }

        public float GetFillingsPrice()
        {
            float price = Fillings.Sum(f => f.Price);

            return (float)Math.Round(price, 2);
        }
    }
}