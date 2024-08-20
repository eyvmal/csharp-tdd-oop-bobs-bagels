using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Onion", 1, true)]
    [TestCase("Chesseburger", 0, false)]
    public void AddBagelTest(string variant, int amount, bool expected)
    {
        Basket basket = new Basket();
        bool result = basket.AddItem("Bagel", variant);

        Assert.That(basket.Items.Count(), Is.EqualTo(amount));
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Onion", 0, true)]
    [TestCase("Chesseburger", 1, false)]
    public void RemoveBagelTest(string variant, int amount, bool expected)
    {
        Basket basket = new Basket();
        basket.AddItem("Bagel", "Onion");
        bool result = basket.RemoveItem("Bagel", variant);

        Assert.That(basket.Items.Count(), Is.EqualTo(amount));
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("Onion", 0.49)]
    [TestCase("Plain", 0.39)]
    public void GetTotalCostTest(string variant, decimal expected)
    {
        Basket basket = new Basket();
        basket.AddItem("Bagel", variant);

        decimal price = basket.GetTotalCost();

        Assert.That(price, Is.EqualTo(expected));
    }

    [Test]
    public void ChangeCapacityTest()
    {
        Basket basket = new Basket();

        Assert.That(BagelShop.Capacity, Is.EqualTo(5));
        BagelShop.ChangeCapacity("manager", 3);
        Assert.That(BagelShop.Capacity, Is.EqualTo(3));
    }

    [Test]
    public void AddFillingTest()
    {
        Bagel bagel = new Bagel("BGLO", 0.49m, "Onion");
        bool result = bagel.AddFilling("ham");

        Assert.That(result, Is.True);
        Assert.That(bagel.Fillings.Count(), Is.EqualTo(1));
    }
    [Test]
    public void RemoveFillingTest()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49m, "Onion");
        bagel.AddFilling("ham");
        bagel.RemoveFilling("ham");

        Item ham = basket.SelectItemFromInventory("filling", "ham");
        bool result = bagel.Fillings.Contains(ham);

        Assert.That(result, Is.False);
        Assert.That(bagel.Fillings.Count(), Is.EqualTo(0));
    }

    [Test]
    public void ChangeFillingTest()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49m, "Onion");
        bagel.AddFilling("ham");

        Item ham = basket.SelectItemFromInventory("filling", "ham");
        bool result = bagel.Fillings.Contains(ham);

        Assert.That(result, Is.True);
    }

    [Test]
    public void GetFillingsPriceTest()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49m, "Onion");
        bagel.AddFilling("ham");
        bagel.AddFilling("Egg");
        bagel.AddFilling("Cheese");

        decimal price = bagel.GetFillingsPrice();

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
        Basket basket = new Basket();
        BagelShop.ChangeCapacity("manager", 25);
        basket.AddItem("coffee", "black");
        for (int i = 0; i < amount; i++)
        {
            basket.AddItem("bagel", "onion");
        }

        Dictionary<string, decimal> discounts = basket.GetDiscounts();

        Assert.That(discounts.Sum(x => x.Value), Is.EqualTo(expected));
    }

}