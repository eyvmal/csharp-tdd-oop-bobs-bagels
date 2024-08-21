namespace exercise.main
{
    public static class Inventory
    {
        public static List<IProduct> Stock { get; } = new List<IProduct> {
            new Bagel("BGLO", 0.49m, "Onion"),
            new Bagel("BGLP", 0.39m, "Plain"),
            new Bagel("BGLE", 0.49m, "Everything"),
            new Bagel("BGLS", 0.49m, "Sesame"),
            new Coffee("COFB", 0.99m, "Black"),
            new Coffee("COFW", 1.19m, "White"),
            new Coffee("COFC", 1.29m, "Cappuccino"),
            new Coffee("COFL", 1.29m, "Latte"),
            new Filling("FILB", 0.12m, "Bacon"),
            new Filling("FILE", 0.12m, "Egg"),
            new Filling("FILC", 0.12m, "Cheese"),
            new Filling("FILX", 0.12m, "Cream Cheese"),
            new Filling("FILS", 0.12m, "Smoked Ham"),
            new Filling("FILH", 0.12m, "Ham"),
        };
    }
}