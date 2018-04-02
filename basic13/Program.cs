using System;
using System.Collections.Generic;   

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print 1-255
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }

            // Print odd numbers between 1-255
            for (int i = 1; i <= 255; i++) 
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
            }

            // Print Sum
            // Write a program that would print the numbers from 0 to 255 but this time, it would also print the sum of the numbers that have been printed so far.
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                sum += i;
                Console.WriteLine("New number: {0}, Sum: {1}", i, sum);
            }

            // Iterating through an Array
            // Given an array X, say [1,3,5,7,9,13], write a program that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.
            int[] X = {1,3,5,7,9,13};
            foreach (int value in X)
            {
                Console.WriteLine(value);
            }

            int[] myArray = {-3, -5, -7, 0, 10};
            FindMax(myArray);
            // You can initialize and pass a new array in one step
            FindMax(new int[] {0, -9, 14, 44, -100});

            GetAverage(new int[] {10, 20, 30});
            GetAverage(new int[] {1, 3, 5, 7});

            ArrayWithOdds();

            int Y = 2;
            int[] anArray = {-5, -4, -1, 0, 3, 10};
            GreaterThanY(Y, anArray);
            GreaterThanY(4, new int[] {2, 4, 30, 50, 1000});

            SquareValues(new int[] {1, 2, 3});
            SquareValues(new int[] {-1, -3, -10});

            NoNegatives(new int[] {-1, 5, 0, -3, -100});

            FindMinMaxAverage(anArray);

            int[] standardArr = {1, 2, 3, 4, 5};
            ShiftValues(standardArr);

            NumberToString(anArray);
        }
        // Find Max
        // Write a program (sets of instructions) that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.
        
        public static int FindMax(int[] arr)
        {
            int maxNum = arr[0];
            foreach (int num in arr)
            {
                if (num > maxNum)
                {
                    maxNum = num;
                }
            }
            Console.WriteLine($"The maximum value of the array is {maxNum}.");
            return maxNum;
        }

        // Get Average
        // Write a program that takes an array, and prints the AVERAGE of the values in the array. 
        public static int GetAverage(int[] arr)
        {
            int arrSum = arr[0];
            foreach (int num in arr)
            {
                arrSum += num;
            }
            int arrAvg = arrSum/arr.Length;
            Console.WriteLine($"The average of the array is {arrAvg}");
            return arrAvg;
        }

        // Array with Odd Numbers
        // Write a program that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
        public static int[] ArrayWithOdds()
        {
            int[] y = new int[128]; // (255/2), rounded up
            for (int i = 0; i < 128; i++)
            {
                if (i % 2 == 1)
                {
                    y[i] = i;
                    Console.WriteLine(y[i]);
                }
            }
            return y;
        }

        // Greater than Y
        // Write a program that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will print 2 (since there are two values in the array that are greater than 3).
        public static int GreaterThanY(int Y, int[] arr)
        {
            int count = 0;
            foreach (int num in arr)
            {
                if (num > Y)
                {
                    count++;
                }
            }
            Console.WriteLine($"There are {count} number(s) greater than your Y value, {Y}, in the array.");
            return count;
        }

        // Square the Values
        // Given any array x, say [1, 5, 10, -2], create an algorithm (sets of instructions) that multiplies each value in the array by itself. When the program is done, the array x should have values that have been squared, say [1, 25, 100, 4].
        public static int[] SquareValues(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= arr[i];
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

        // Eliminate Negative Numbers
        // Given any array x, say [1, 5, 10, -2], create an algorithm that replaces any negative number with the value of 0. When the program is done, x should have no negative values, say [1, 5, 10, 0].
        public static int[] NoNegatives(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

        // Min, Max, and Average
        // Given any array x, say [1, 5, 10, -2], create an algorithm that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        public static string FindMinMaxAverage(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            int sum = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                sum += arr[i];
            }

            float average = ((float)sum / arr.Length);
            string summary = $"Min: {min},\n Max: {max},\n Average: {average},\n Sum: {(double)sum},\n Length: {(double)arr.Length}";

            Console.WriteLine(summary);
            return summary;
        }

        // Shifting the values in an array
        // Given any array x, say [1, 5, 10, 7, -2], create an algorithm that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        public static int[] ShiftValues(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
                Console.WriteLine(arr[i]);
            }
            int lastVal = arr[arr.Length-1] = 0;
            Console.WriteLine(lastVal);
            return arr;
        }

        // Number to String
        // Write a program that takes an array of numbers and replaces any negative number with the string 'Dojo'. For example, if array x is initially [-1, -3, 2] your function should return an array with values ['Dojo', 'Dojo', 2].

        public static List<object> NumberToString(int[] arr)
        {
            List<object> dojoList = new List<object>();
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    dojoList.Add("Dojo");
                }
                else
                {
                    dojoList.Add(arr[i]);
                }
                Console.WriteLine(dojoList[i]);
            }
            return dojoList;
        }
    }
}
