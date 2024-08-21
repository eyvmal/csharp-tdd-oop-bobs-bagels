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
            Fillings.Add(new Filling(product.Code, product.Price, product.Variant));
            return true;
        }

        public bool RemoveFilling(string variant)
        {
            var product = Fillings.FirstOrDefault(x => x.Name.Equals("Filling") && x.Variant.ToLower().Equals(variant.ToLower()))!;

            if (product == null) return false;
            Fillings.Remove(product);
            return true;
        }

        public bool ChangeFilling(string oldFilling, string newFilling)
        {
            var remove = RemoveFilling(oldFilling);
            var add = AddFilling(newFilling);
            return remove && add;
        }

        public decimal GetPrice() { return Price + GetFillingsPrice(); }

        public decimal GetFillingsPrice()
        {
            var price = Fillings.Sum(f => f.Price);

            return price;
        }
    }
}