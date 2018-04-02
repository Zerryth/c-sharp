using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> myList = new List<object>();

            // dd the following values to the list: 7, 28, -1, true, "chair"
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");

            // Loop through the list and print all values (Hint: Type Inference might help here!)
            foreach (var entry in myList)
            {
                Console.WriteLine(entry);
            }

            // Add all values that are Int type together and output the sum
            int sum = 0;
            foreach (var entry in myList)
            {
                if (entry is int)
                {
                    // sum += Convert.ToInt32(entry); // this works as well
                    sum += (int)entry;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
