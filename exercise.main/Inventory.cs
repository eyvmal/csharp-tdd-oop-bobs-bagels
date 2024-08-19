using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public static class Inventory
    {
        public static List<Item> Items { get; set; } = new List<Item> {
            new Bagel("BGLO", 0.49f, "Onion"),
            new Bagel("BGLP", 0.39f, "Plain"),
            new Bagel("BGLE", 0.49f, "Everything"),
            new Bagel("BGLS", 0.49f, "Sesame"),
            new Coffee("COFB", 0.99f, "Black"),
            new Coffee("COFW", 1.19f, "White"),
            new Coffee("COFC", 1.29f, "Capuccino"),
            new Coffee("COFL", 1.29f, "Latte"),
            new Filling("FILB", 0.12f, "Bacon"),
            new Filling("FILE", 0.12f, "Egg"),
            new Filling("FILC", 0.12f, "Cheese"),
            new Filling("FILX", 0.12f, "Cream Cheese"),
            new Filling("FILS", 0.12f, "Smoked Ham"),
            new Filling("FILH", 0.12f, "Ham"),
        };
    }
}