using System.Text;

namespace exercise.main
{
    public class Receipt
    {
        private DateTime _receiptDate;
        private string _shopName;
        private decimal _totalPrice;
        private decimal _totalDiscount;
        private List<IProduct> _items;
        private Dictionary<string, decimal> _discounts;
        private string _receipt;

        public Receipt(Basket basket)
        {
            _receiptDate = DateTime.Now;
            _shopName = BagelShop.Name;
            _items = basket.Products;
            _totalPrice = basket.GetTotalCost();
            _discounts = basket.GetDiscounts();
            _totalDiscount = _discounts.Sum(x => x.Value);
            _receipt = GenerateReceipt();
        }

        private string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"     ~~~ {_shopName} ~~~\n");
            sb.AppendLine($"     {_receiptDate:yyyy-MM-dd HH:mm:ss}\n");
            sb.AppendLine($"------------------------------\n");

            var groupedItems = _items
                .GroupBy(item => new { item.Name, item.Variant })
                .Select(group =>
                {
                    var firstItem = group.First();
                    var isBagel = firstItem.Code.StartsWith("BGL");

                    List<IProduct> fillings = isBagel
                        ? group.OfType<Bagel>()
                            .SelectMany(x => x.Fillings)
                            .ToList()
                        : new List<IProduct>();
                    
                    var groupedFillings = fillings.GroupBy(x => x.Variant)
                        .Select(fillingGroup => new
                        {
                            Variant = fillingGroup.Key,
                            Quantity = fillingGroup.Count(),
                            TotalPrice = fillingGroup.Sum(x => x.Price)
                        });
                    
                    _totalPrice += groupedFillings.Sum(filling => filling.TotalPrice);
                    
                    return new
                    {
                        Code = group.First().Code,
                        Name = $"{group.Key.Variant} {group.Key.Name}",
                        Quantity = group.Count(),
                        TotalPrice = group.Sum(item => item.Price),
                        Fillings = groupedFillings,
                    };
                })
                .OrderBy(item => item.Name);

            foreach (var item in groupedItems)
            {
                sb.AppendLine($"{item.Name.PadRight(20)} {item.Quantity.ToString().PadRight(3)} £{item.TotalPrice:F2}");
                if (_discounts.ContainsKey(item.Code))
                {
                    sb.AppendLine($"                       (-£{_discounts[item.Code]})");
                }

                foreach (var filling in item.Fillings)
                {
                    sb.AppendLine($" \u21b3 {filling.Variant.PadRight(17)} {filling.Quantity.ToString().PadRight(3)} £{filling.TotalPrice:F2}");
                }
            }

            sb.AppendLine($"------------------------------\n");
            decimal adjustedPrice = _totalPrice - _totalDiscount;
            sb.AppendLine($"Total price:              {adjustedPrice}\n\n");

            if (_totalDiscount > 0)
            {
                sb.AppendLine($"   You saved a total of £{_totalDiscount}");
                sb.AppendLine($"        on this shop!\n\n");
            }

            sb.AppendLine($"           Thank you");
            sb.AppendLine($"        for your order!");

            return sb.ToString();
        }

        public void PrintReceipt()
        {
            Console.WriteLine(_receipt);
        }
    }
}
