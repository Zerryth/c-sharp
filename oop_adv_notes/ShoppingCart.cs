using System.Collections.Generic;
using System;
namespace oop_adv_notes{

    // Assume this is the class provided that we can not edit.
    public class ShoppingCart
    {
        public List<Product> Products { get; set; }
    }
    // This is the wrapper for our extension
    // Note the static keyword
    public static class MyExtensionMethods
    {
        // This still only effectst he ShoppingCart class
        // Note how the parameters for the new function is previous class
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam.Products)
            {
                total += prod.price;
            }
            return total;
        }

        // From here an extension method is in place and the class will have access to that function when called as normal. Note they do have to be in the same namespace, but not necessarily the same file.

        // This method is added to everything that uses the CanRun interface though!
        public static double MarathonDistance(this CanRun creature)
        {
            creature.Run();
            Console.WriteLine("I'm running a marathon!");
            return 26.2;
        }
    }
}
