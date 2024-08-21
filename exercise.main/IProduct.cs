namespace exercise.main
{
    public interface IProduct
    {
        string Code { get; set; }
        decimal Price { get; set; }
        string Name { get; set; }
        string Variant { get; set; }
    }
}