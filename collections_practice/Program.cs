using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // THREE BASIC ARRAYS
            // Create an array to hold integer values 0 through 9
            int[] array1 = new int[10];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i;
            }
            // or
            int[] array2 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};

            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] booleanArr = new bool[10];
            for (int i = 0; i < booleanArr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    booleanArr[i] = true;
                }
                else
                {
                    booleanArr[i] = false;
                }
            }

            // MULTIPLICATION TABLE
            // With the values 1-10, use code to generate a multiplication table like the one below.
            // [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
            // [2, 4, 6, 8, 10, 12, 14, 16, 18, 20],
            // [3, 6, 9, 12, 15, 18, 21, 24, 27, 30],
            // [4, 8, 12, 16, 20, 24, 28, 32, 36, 40],
            // [5, 10, 15, 20, 25, 30, 35, 40, 45, 50],
            // etc.
            // Use a multi-dimensional array to store all values
            int[,] multiplicationTable = new int[10, 10];
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    multiplicationTable[row, column] = (row + 1) * (column + 1);
                }
            }

            // LIST OF FLAVORS
            // Create a list of Ice Cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            string[] flavors = {"Pralines 'n' Creme", "Butter Pecan", "Strawberry", "Chocolate Mint", "Birthday Cake"};
            List<string> flavorsList = new List<string>();
            for (var i = 0; i < flavors.Length; i++)
            {
                flavorsList.Add(flavors[i]);
            }

            // Output the length of this list after building it
            Console.WriteLine("The length of our Ice Cream flavorsList is {0}", flavorsList.Count);

            // Output the third flavor in the list, then remove this value.
            Console.WriteLine("The 3rd flavor in this list is {0}.", flavorsList[2]);
            flavorsList.RemoveAt(2);
            Console.WriteLine("Now we have removed the 3rd element. The new 3rd element in the flavorsList is {0}.", flavorsList[2]);

            // Output the new length of the list (Note it should just be one less~)
            Console.WriteLine("The new length of the list is now " + flavorsList.Count + ".");
        }
    }
}
