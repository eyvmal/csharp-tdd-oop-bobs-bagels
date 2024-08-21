using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Onion", 1, true)]
    [TestCase("Cheeseburger", 0, false)]
    public void AddBagelTest(string variant, int amount, bool expected)
    {
        var basket = new Basket();
        var result = basket.AddProduct("Bagel", variant);

        Assert.That(basket.Products.Count(), Is.EqualTo(amount));
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Onion", 0, true)]
    [TestCase("Cheeseburger", 1, false)]
    public void RemoveBagelTest(string variant, int amount, bool expected)
    {
        var basket = new Basket();
        basket.AddProduct("Bagel", "Onion");
        var result = basket.RemoveProduct("Bagel", variant);

        Assert.That(basket.Products.Count(), Is.EqualTo(amount));
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Onion", 0.49)]
    [TestCase("Plain", 0.39)]
    public void GetTotalCostTest(string variant, decimal expected)
    {
        var basket = new Basket();
        basket.AddProduct("Bagel", variant);

        var price = basket.GetTotalCost();

        Assert.That(price, Is.EqualTo(expected));
    }

    [Test]
    public void ChangeCapacityTest()
    {
        Assert.That(BagelShop.Capacity, Is.EqualTo(5));
        BagelShop.ChangeCapacity("manager", 3);
        Assert.That(BagelShop.Capacity, Is.EqualTo(3));
    }

    [Test]
    public void AddFillingTest()
    {
        var bagel = new Bagel("BGLO", 0.49m, "Onion");
        var result = bagel.AddFilling("ham");

        Assert.That(result, Is.True);
        Assert.That(bagel.Fillings.Count(), Is.EqualTo(1));
    }
    [Test]
    public void RemoveFillingTest()
    {
        var basket = new Basket();
        var bagel = new Bagel("BGLO", 0.49m, "Onion");
        bagel.AddFilling("ham");
        bagel.RemoveFilling("ham");

        var ham = basket.SelectProductFromInventory("filling", "ham");
        var result = bagel.Fillings.Contains(ham);

        Assert.That(result, Is.False);
        Assert.That(bagel.Fillings.Count(), Is.EqualTo(0));
    }

    [Test]
    public void ChangeFillingTest()
    {
        var basket = new Basket();
        var bagel = new Bagel("BGLO", 0.49m, "Onion");
        bagel.AddFilling("ham");

        var ham = basket.SelectProductFromInventory("filling", "ham");
        var result = bagel.Fillings.Contains(ham);

        Assert.That(result, Is.True);
    }

    [Test]
    public void GetFillingsPriceTest()
    {
        var bagel = new Bagel("BGLO", 0.49m, "Onion");
        bagel.AddFilling("ham");
        bagel.AddFilling("Egg");
        bagel.AddFilling("Cheese");

        var price = bagel.GetFillingsPrice();

        Assert.That(price, Is.EqualTo(0.36m));
    }

    [TestCase(1, 0.23)]
    [TestCase(6, 0.45)]
    [TestCase(7, 0.68)]
    [TestCase(12, 1.89)]
    [TestCase(13, 2.12)]
    [TestCase(18, 2.34)]
    [TestCase(19, 2.57)]
    [TestCase(24, 3.78)]
    public void GetDiscountsTest(int amount, decimal expected)
    {
        var basket = new Basket();
        BagelShop.ChangeCapacity("manager", 25);
        basket.AddProduct("coffee", "black");
        for (var i = 0; i < amount; i++)
        {
            basket.AddProduct("bagel", "onion");
        }
        var discounts = basket.GetDiscounts();
        Assert.That(discounts.Sum(x => x.Value), Is.EqualTo(expected));
    }

}