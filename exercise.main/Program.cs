// See https://aka.ms/new-console-template for more information
using exercise.main;

Basket b = new Basket();
BagelShop.ChangeCapacity("manager", 25);

for (int i = 0; i < 10; i++)
{
    b.AddProduct("bagel", "onion");
}
b.AddProduct("coffee", "black");
b.AddProduct("bagel", "onion");
b.AddProduct("coffee", "latte");
b.AddProduct("filling", "bacon");

Receipt r = new Receipt(b);

r.PrintReceipt();