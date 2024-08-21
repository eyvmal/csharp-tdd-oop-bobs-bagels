namespace exercise.main
{
    public static class BagelShop
    {
        public static int Capacity { get; set; } = 5;
        public static string Name { get; set; } = "Bob's Bagels";

        public static bool ChangeCapacity(string role, int newCapacity)
        {
            if (!role.Equals("manager")) return false;
            Capacity = newCapacity;
            return true;
        }
    }
}