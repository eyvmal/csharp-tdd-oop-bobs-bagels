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
        private Dictionary<string, decimal> _discounts;
        private string _receipt;

        public Receipt(Basket basket)
        {
            _receiptDate = DateTime.Now;
            _shopName = BagelShop.Name;
            _totalPrice = basket.GetTotalCost();
            _discounts = basket.GetDiscounts();
            _receipt = GenerateReceipt();
        }

        private string GenerateReceipt() { return string.Empty; }

        public void PrintReceipt()
        {

        }
    }
}
