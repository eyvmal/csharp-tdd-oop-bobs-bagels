namespace exercise.main
{
    public class Bagel : IProduct
    {

        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public List<IProduct> Fillings { get; set; }

        public Bagel(string code, decimal price, string variant)
        {
            Code = code;
            Price = price;
            Name = "Bagel";
            Variant = variant;
            Fillings = new List<IProduct>();
        }

        public bool AddFilling(string variant)
        {
            var product = Inventory.Stock.FirstOrDefault(x => x.Name.Equals("Filling") && x.Variant.ToLower().Equals(variant.ToLower()))!;

            if (product == null) return false;
            Fillings.Add(product);
            return true;
        }

        public bool RemoveFilling(string variant)
        {
            var product = Inventory.Stock.FirstOrDefault(x => x.Name.Equals("Filling") && x.Variant.ToLower().Equals(variant.ToLower()))!;

            if (product == null) return false;
            Fillings.Remove(product);
            return true;
        }

        public bool ChangeFilling(string oldFilling, string newFilling)
        {
            var oldFill = Inventory.Stock.FirstOrDefault(x => x.Name.ToLower().Equals("filling") && x.Variant.ToLower().Equals(oldFilling.ToLower()));
            var newFill = Inventory.Stock.FirstOrDefault(x => x.Name.ToLower().Equals("filling") && x.Variant.ToLower().Equals(newFilling.ToLower()));

            if (oldFill == null || newFill == null) return false;
            Fillings.Remove(oldFill);
            Fillings.Add(newFill);
            return true;
        }

        public decimal GetPrice() { return Price + GetFillingsPrice(); }

        public decimal GetFillingsPrice()
        {
            var price = Fillings.Sum(f => f.Price);

            return price;
        }
    }
}