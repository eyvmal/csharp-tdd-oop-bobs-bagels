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

            // Standard overskrift hvor _shopName er hentet fra den statiske BagelShop-klassen
            // og _receiptDate er tidspunktet her og nå, men formattert slik jeg ønsker.
            sb.AppendLine($"     ~~~ {_shopName} ~~~\n");
            sb.AppendLine($"     {_receiptDate:yyyy-MM-dd HH:mm:ss}\n");
            sb.AppendLine($"------------------------------\n");

            // Grupperer alle produktene i handlekurven basert på Navn og Variant
            var groupedItems = _items
                .GroupBy(item => new { item.Name, item.Variant })
                .Select(group =>
                {
                    // Jeg sjekker Koden til første produkt i gruppen for å se om det er en Bagel
                    var firstItem = group.First();
                    var isBagel = firstItem.Code.StartsWith("BGL");

                    // Hvis det er en Bagel, lager jeg en felles liste med alle
                    // fillingene til alle bagelene i denne gruppen
                    List<IProduct> fillings = isBagel
                        ? group.OfType<Bagel>()
                            .SelectMany(x => x.Fillings)
                            .ToList()
                        : new List<IProduct>();
                    
                    // Så grupperer jeg fillingsene på samme måte som produktene i handlekurven (samme som linje 37)
                    var groupedFillings = fillings.GroupBy(x => x.Variant)
                        .Select(fillingGroup => new
                        {
                            // Her bestemmer jeg bare hvilke verdier som skal lagres i dene nye listen med grupperinger
                            Variant = fillingGroup.Key,
                            Quantity = fillingGroup.Count(),
                            TotalPrice = fillingGroup.Sum(x => x.Price)
                        });
                    
                    // Legger til summen av fillingPriser til totalPrisen
                    _totalPrice += groupedFillings.Sum(filling => filling.TotalPrice);
                    
                    return new
                    {
                        // Samme som med fillingsene bestemmer jeg her hvilke verdier
                        // jeg ønsker å lagre i gruppen med produkter
                        Code = group.First().Code,
                        Name = $"{group.Key.Variant} {group.Key.Name}",
                        Quantity = group.Count(),
                        TotalPrice = group.Sum(item => item.Price),
                        Fillings = groupedFillings,
                    };
                })
                .OrderBy(item => item.Name);

            // Printing av hvert produkt i listen over grupperte produkter
            foreach (var item in groupedItems)
            {
                // PadRight og PadLeft er kun for å formattere utskriften pent.
                // Man må bare teste seg frem til riktige verdier...
                sb.AppendLine($"{item.Name.PadRight(20)} {item.Quantity.ToString().PadRight(3)} £{item.TotalPrice:F2}");
                
                // Hvis koden på dette produktet finens i dictionarien med rabatter
                // Så legger man her til rabatten på kvitteringen.
                if (_discounts.ContainsKey(item.Code))
                {
                    sb.AppendLine($"                       (-£{_discounts[item.Code]})");
                }

                // Deretter itererer jeg gjennom alle fillingsene i den grupperte filling-listen
                // og skriver det på kvitteringen på samme måte som selve produktene
                foreach (var filling in item.Fillings)
                {
                    sb.AppendLine($" \u21b3 {filling.Variant.PadRight(17)} {filling.Quantity.ToString().PadRight(3)} £{filling.TotalPrice:F2}");
                }
            }
            
            // Og resten er bare slutten på kvitteringen
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
