using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddBagelTest()
    {
        Basket basket = new Basket();
        bool result = basket.AddItem("Bagel", "Onion");

        List<Item> expected = new List<Item>();
        expected.Add(new Bagel("BGLO", 0.49f, "Onion"));

        Assert.That(basket.Items.Count(), Is.EqualTo(1));
        Assert.That(result, Is.True);
    }

    [Test]
    public void RemoveBagelTest()
    {
        Basket basket = new Basket();
        basket.AddItem("Bagel", "Onion");
        bool result = basket.RemoveItem("Bagel", "Onion");

        Assert.That(basket.Items.Count(), Is.EqualTo(0));
        Assert.That(result, Is.True);
    }

    [Test]
    public void GetTotalCostTest()
    {
        Basket basket = new Basket();
        basket.AddItem("Bagel", "Onion");

        float price = basket.GetTotalCost();

        Assert.That(price, Is.EqualTo(0.49f));
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
        Assert.Pass();
    }

    [Test]
    public void ChangeFillingTest()
    {
        Assert.Pass();
    }

}