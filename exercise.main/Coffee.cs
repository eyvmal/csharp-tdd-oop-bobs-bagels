namespace exercise.main
{
    public class Coffee : IProduct
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Coffee(string code, decimal price, string variant)
        {
            Code = code;
            Price = price;
            Name = "Coffee";
            Variant = variant;
        }
    }
}