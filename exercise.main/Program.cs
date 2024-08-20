// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");

Basket b = new Basket();
BagelShop.ChangeCapacity("manager", 25);

for (int i = 0; i < 10; i++)
{
    b.AddItem("bagel", "onion");
}
b.AddItem("coffee", "black");
b.AddItem("bagel", "onion");
b.AddItem("coffee", "lattee");
b.AddItem("filling", "bacon");

Receipt r = new Receipt(b);

r.PrintReceipt();