using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public static class BagelShop
    {
        public static int Capacity { get; set; } = 5;

        public static bool ChangeCapacity(string role, int newCapacity)
        {
            if (role.Equals("manager"))
            {
                Capacity = newCapacity;
                return true;
            }
            return false;
        }
    }
}