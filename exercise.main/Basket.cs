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
            Item item = SelectItemFromInventory(name, variant);

            if (item != null)
            {
                if (Items.Count() < BagelShop.Capacity)
                {
                    if (item.Name.Equals("Bagel"))
                    {
                        Items.Add(new Bagel(item.Code, item.Price, item.Variant));
                        return true;
                    }
                    else if (item.Name.Equals("Coffee"))
                    {
                        Items.Add(new Coffee(item.Code, item.Price, item.Variant));
                        return true;
                    }
                    else if (item.Name.Equals("Filling"))
                    {
                        Items.Add(new Filling(item.Code, item.Price, item.Variant));
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public bool RemoveItem(string name, string variant)
        {
            Item item = SelectItemFromBasket(name, variant);

            if (item != null)
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public decimal GetTotalCost()
        {

            decimal price = 0;

            foreach (Item i in Items)
            {
                price += i.Price;
            }

            return price;
        }

        public Item SelectItemFromInventory(string name, string variant)
        {
            return Inventory.Items.Where(i => i.Name.ToLower().Equals(name.ToLower()) && i.Variant.ToLower().Equals(variant.ToLower())).FirstOrDefault();
        }

        public Item SelectItemFromBasket(string name, string variant)
        {
            return Items.Where(i => i.Name.ToLower().Equals(name.ToLower()) && i.Variant.ToLower().Equals(variant.ToLower())).FirstOrDefault();
        }

        public Dictionary<string, decimal> GetDiscounts()
        {
            Dictionary<string, decimal> discounts = new Dictionary<string, decimal> { { "null", 0 } };
            List<Item> cpyItems = new List<Item>(Items);

            foreach (Item item in Inventory.Items)
            {
                if (item.Name.Equals("Bagel"))
                {
                    int amount = cpyItems.Where(x => x.Code.Equals(item.Code)).Count();
                    decimal discount = 0m;
                    if (amount >= 12)
                    {
                        int dozens = amount / 12;
                        discount += dozens * 3.99m;
                        amount -= dozens * 12;

                        cpyItems.RemoveAll(x => x.Code.Equals(item.Code) && dozens-- > 0);
                    }
                    if (amount >= 6)
                    {
                        int halfDozens = amount / 6;
                        discount += halfDozens * 2.49m;
                        amount -= halfDozens * 6;

                        cpyItems.RemoveAll(x => x.Code.Equals(item.Code) && halfDozens-- > 0);
                    }
                    discounts[item.Code] = discount;
                }
                else if (item.Code.Equals("COFB"))
                {
                    int coffee = cpyItems.Where(x => x.Code.Equals(item.Code)).Count();
                    int bagel = cpyItems.Where(x => x.Name.Equals("Bagel")).Count();
                    int lower = Math.Min(coffee, bagel);

                    discounts[item.Code] = 1.25m * lower;
                }
            }
            return discounts;
        }
    }
}