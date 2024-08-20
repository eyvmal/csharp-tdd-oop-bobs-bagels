using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Receipt
    {
        private DateTime _receiptDate;
        private string _shopName;
        private decimal _totalPrice;
        private List<Item> _items;
        private Dictionary<string, decimal> _discounts;
        private string _receipt;

        public Receipt(Basket basket)
        {
            _receiptDate = DateTime.Now;
            _shopName = BagelShop.Name;
            _items = basket.Items;
            _totalPrice = basket.GetTotalCost();
            _discounts = basket.GetDiscounts();
            _receipt = GenerateReceipt();
        }

        private string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{_shopName}\n");
            sb.AppendLine($"{_receiptDate:yyyy-MM-dd HH:mm:ss}\n");

            var groupedItems = _items
                .GroupBy(item => new { item.Name, item.Variant })
                .Select(group => new
                {
                    Name = $"{group.Key.Variant} {group.Key.Name}",
                    Quantity = group.Count(),
                    TotalPrice = group.Sum(item => item.Price)
                })
                .OrderBy(item => item.Name);

            foreach (var item in groupedItems)
            {
                sb.AppendLine($"{item.Name} {item.Quantity} {item.TotalPrice}");
            }

            sb.AppendLine($"Total price: {_totalPrice}");

            return sb.ToString();
        }

        public void PrintReceipt()
        {
            Console.WriteLine(_receipt);
        }
    }
}
