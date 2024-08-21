namespace exercise.main
{
    public class Basket
    {
        public List<IProduct> Products { get; }

        public Basket()
        {
            Products = new List<IProduct>();
        }

        public bool AddProduct(string name, string variant)
        {
            var product = SelectProductFromInventory(name, variant);

            if (product == null) return false;
            if (Products.Count() >= BagelShop.Capacity) return false;
            switch (product.Name)
            {
                case "Bagel":
                    Products.Add(new Bagel(product.Code, product.Price, product.Variant));
                    return true;
                case "Coffee":
                    Products.Add(new Coffee(product.Code, product.Price, product.Variant));
                    return true;
                case "Filling":
                    Products.Add(new Filling(product.Code, product.Price, product.Variant));
                    return true;
                default:
                    return false;
            }
        }

        public bool RemoveProduct(string name, string variant)
        {
            var product = SelectProductFromBasket(name, variant);

            if (product == null) return false;
            Products.Remove(product);
            return true;
        }

        public decimal GetTotalCost()
        {
            decimal price = 0;
            foreach (var p in Products)
            {
                price += p.Price;
            }
            return price;
        }

        public IProduct SelectProductFromInventory(string name, string variant)
        {
            return Inventory.Stock.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()) && x.Variant.ToLower().Equals(variant.ToLower()))!;
        }

        public IProduct SelectProductFromBasket(string name, string variant)
        {
            return Products.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()) && x.Variant.ToLower().Equals(variant.ToLower()))!;
        }

        public Dictionary<string, decimal> GetDiscounts()
        {
            var discounts = new Dictionary<string, decimal> { { "null", 0 } };
            var cpyProducts = new List<IProduct>(Products);

            foreach (var product in Inventory.Stock)
            {
                decimal discount = 0m;
                if (product.Name.Equals("Bagel"))
                {
                    int amount = cpyProducts.Where(x => x.Code.Equals(product.Code)).Count();
                    int totalItemsToRemove = 0;
                    if (amount >= 12) // Check for dozens
                    {
                        int dozens = amount / 12;
                        discount += dozens * 1.89m;
                        totalItemsToRemove += dozens * 12;
                        amount -= dozens * 12;
                    }
                    if (amount >= 6) // Check for half dozens
                    {
                        int halfDozens = amount / 6;
                        discount += halfDozens * 0.45m;
                        totalItemsToRemove += halfDozens * 6;
                    }
                    // Remove items
                    for (int i = 0; i < totalItemsToRemove; i++)
                    {
                        cpyProducts.Remove(cpyProducts.First(x => x.Code.Equals(product.Code)));
                    }
                    // Add discount
                }
                else if (product.Code.Equals("COFB"))
                {
                    var coffee = cpyProducts.Count(x => x.Code.Equals(product.Code));
                    var bagel = cpyProducts.Count(x => x.Name.Equals("Bagel"));
                    var lower = Math.Min(coffee, bagel);

                    if (lower > 0) discount = 0.23m * lower;
                }
                if (discount > 0) discounts[product.Code] = discount;
            }
            return discounts;
        }
    }
}