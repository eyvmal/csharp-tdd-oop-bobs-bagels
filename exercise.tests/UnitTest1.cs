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
        Bagel bagel = new Bagel();
        bool result = basket.AddItem(bagel);

        List<Item> expected = new List<Item>();
        expected.Add(bagel);

        Assert.That(basket.Items, Is.EqualTo(expected));
        Assert.That(result, Is.True);
    }

    [Test]
    public void RemoveBagelTest()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel();
        basket.AddItem(bagel);
        basket.AddItem(bagel);
        bool result = basket.RemoveItem(bagel);

        List<Item> expected = new List<Item>();
        expected.Add(bagel);

        Assert.That(basket.Items, Is.EqualTo(expected));
        Assert.That(result, Is.True);
    }

    [Test]
    public void GetTotalPriceTest()
    {
        Assert.Pass();
    }

    [Test]
    public void ChangeCapacityTest()
    {
        Assert.Pass();
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