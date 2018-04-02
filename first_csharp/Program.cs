using System;
using System.Collections.Generic;
namespace first_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Implicit Casting
            int IntegerValue = 65;
            double DoubleValue = IntegerValue;
                // implicit casting allows us to convert a variable from one type to another
                // as long as the conversion doesn't include any loss of information
                // implicit casting of numerical values therefore is valid when going from values of lower precision to higher precision
            
            // Explicit Casting
            double anotherDoubleValue = 3.14159265358;
            int anotherInteger = (int)anotherDoubleValue;
            // => anotherInteger == 3;

            // Note, most DataTypes cannot be converted with a simple type cast
                // strings cannot be converted to an integer, 
                // string of "True" cannot be converted to a Boolean
            // if you wanted to do this, you must use a method to remove the data stored in the type's memory, and reformat it for storage as a new type
                // strings, as they are so common, luckily have a .ToString() method
            int num =  7;
            string stringAsString = num.ToString(); // evaluates as "7";
            double stringAsInt = Convert.ToDouble(stringAsString);

            System.Console.WriteLine("Using Console.WriteLine(), you can output any string to the terminal/console");
            // so long as the type as a valid .ToString method, you can Console.WriteLine variables of non-string types
            int favoriteNum = 42;
            System.Console.WriteLine(favoriteNum + " is my favorite num!"); // string concatonation

            // Mixing of Strings & other variables can be accomplished by placing tokens inside your output string, and supplying the WriteLine function with additional parameters or by making use of string concatonation
            Console.WriteLine("The {0} cow jumped over the {1}, {2} times!", "brown", "moon", 7);
            // => "The brown cow jumped over the moon, 7 times!"

            // Can even perform operations directly on a string by making use of string interpolation
            string interpol = $"The answer to 2 + 7 is {2+7}";
            Console.WriteLine(interpol);

            Console.WriteLine("here \n and there");

            // CONDIDTIONALS
            // declare variable called rings of int type
            int rings = 5;
            if (rings >= 5)
            {
                System.Console.WriteLine("You are welcome to join the party.");
            }
            else
            {
                System.Console.WriteLine("Go win some more rings!");
            }
            // if we have more than one condition, we can use an else if statement:
            int yourRings = 3;
            if (yourRings >= 5)
            {
                System.Console.WriteLine("You are welcome to join the party.");
            }
            else if (yourRings > 2)
            {
                System.Console.WriteLine("Decent...but {0} rings aren't enough.", yourRings);
            }
            else
            {
                System.Console.WriteLine("Go win some more rings!");
            }

            // Equality vs. Identity
            // == checks if instance of left & right are equal
            // two instances can be equal, but they don't need to have the same memory location
            // can check if instances share same memory location by using identiy operators:
                // A.Equals(B) with A and B being the respective variables
            
            // We can use logical operators in our Conditionals as well
            int usersRings = 5;
            const string name = "Kobe";
            if (usersRings >= 5 && name == "Kobe")
            {
                System.Console.WriteLine("Welcome to the party {0}, congratulations on your {1} rings!", name, usersRings);
            }

            int numRings = 5;
            int numOfAllStarAppearances = 17;
            if (numRings >= 5 || numOfAllStarAppearances >= 3)
            {
                System.Console.WriteLine("Welcome. You are truly a legend.");
            }
            bool crazy = true;
            if (!crazy)
            {
                System.Console.WriteLine("Let's party!");
            }

            // LOOPS
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            int start = 0;
            int end = 5;
            for (int i = start; i < end; i++)
            {
                System.Console.WriteLine(i);
            }

            // the execution section does not always have to use ++
            for (int i = 1; i < 10; i = i + 2)
            {
                System.Console.WriteLine(i);
            }

            // ...as a while loop
            int j = 1;
            while (j < 10)
            {
                System.Console.WriteLine(j);
                j = j + 2;
            }

            // Generating RANDOM Values in C#
            // the ability to generate random values comes from namespace System
            // create random object
            Random rand = new Random();
                // this object acts like a generator for all things random
                // on construction, it takes a snapshot of our system clock-time to utilize for generating psuedo-random values
                // once the random object is constructed, we have a few methods available but one in particular we're going to focus on is the .Next() method
            // .NEXT()
            // .Next() is focused completely on performing a mathematical operation on a seed value that the random object holds and producing a new pseudo-random value
            //  THE BEST WAY TO PRODUCE CONSECUTIVE RANDOM VALUES IS TO CONTINUE TO CALL THE .NEXT METHOD
            // .Next() 
                // a 32-bit signed integer that is >= 0 and less than maxValue
            // .Next(Int32)
                // Similar to .Next(), but the provided parameter represents that maxValue
            // .Next(Int32, Int32)
                // Similar to .Next(), but the provided parameters represent the minValue & maxValue for the range of numbers to randomize between
            // .NextDouble() 
                // returns a random floating-point number that is >= 0.0 and less than 1.0
            
            
            // So making use of our random object, we can generate 10 random values between 2 and 10 by calling .Next(2,8) in a for loop.
            Random randomNumber = new Random(); // random object created OUTSIDE the for loop
            for (int i = 0; i < 10; i++)
            {
                // prints the next random value between 2 and 8
                System.Console.WriteLine(randomNumber.Next(2,8));
            }

            // ARRAYS
            // arrays ar similar in C# to JS & Python in that they are a numerically indexed collection of values, however, unlike JS & Python, in C# ARRAYS MUST HAVE AN EXACT LENGTH THAT IS SPECIFIED WHEN THE ARRAY IS CREATED

            // declaring an array of length 5, initialized by default to all zeroes
            int[] numArray = new int[5];
            //declaring an array with pre-populated values
            // For arrays initialized this way, the length is determined by the size of the given data
            int[] numArray2 = {1, 2, 3, 4, 6, 110};
            // [] denote Array type, and preceding the brackets we put the type of the values that we will store

            // it is possible to declare an array without initialization, but you must use the "new" operator once you've defined the arrays values
            int[] array3;
            array3 = new int[] {1, 3, 48, 29, 3};

            // Accessing arrays
            int[] arrayOfInts = {1, 2, 3, 4, 5};
            Console.WriteLine(arrayOfInts[2] + " is the value at index 2 of arrayOfInts");
            // we can redefine the value at a particular index as well
            int[] arr = {1, 2, 3, 4};
            Console.WriteLine("The first numer of the array is " + arr[0]);
            arr[0] = 8;
            Console.WriteLine("The first numer of the array is now " + arr[0]);

            // iterating through an array
            string[] myCars = new string[4] {"Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
                // the 'Length' property tells us how many values are in the array--in example, 4
                // can use this to determine where loop ends; Length-1 is the index of the last value
            for (int idx = 0; idx < myCars.Length; idx++)
            {
                Console.WriteLine("I own a {0}", myCars[idx]);
            }

            // C# language also includes another type of loop, foreach loopi
                // a foreach loop just needs a variable to hold each indexed value of the array temporarily and will loop through all of them from there
            string[] myCars2 = new string[4] {"Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
            foreach (string car in myCars2)
            {
                // we no longer need the index, because variable 'car' already contains each indexed value
                Console.WriteLine("I own a {0}", car);
            }


            // Multi-Dimensional Arrays

            // this example contains 3 arrays -- each of these is length 2 -- all initialized to 0s;
            int [,] array2D = new int[3,2];
            // This is equivalent to:
            // int [,] array2D = new int[3,2] { [0, 0], [0, 0], [0, 0] };

            // This example has 2 large rows that each contains 3 arrays -- and ea. of those arrays is length 4
            int [,,] array3D = new int[2, 3, 4]
            {
                { {1, 2, 3, 4}, {5, 55, 70, 2}, {0, 0, 22, 13} },
                { {60, 70, 80, 90}, {10, 20, 55, 5}, {1, 2, 2, 8} }
            };

            // What if we need to vary the length of inner arrays?
            // 3rd way of creating arrays is called a jagged array
            // Jagged array declaration
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[4]; 
            jaggedArray[2] = new int[2];
            int[][] jaggedArray2 = new int[][] {
                new int[] {1,3,5,7,9},
                new int[] {0,2},
                new int[] {11,22,33,44}
            };
            // Short-hand form
            int[][] jaggedArray3 = {
                new int[] {1,3,5,7,9},
                new int[] {0,2},
                new int[] {11,22,33,44}
            };
            // You can even mix jagged and multi-dimensional arrays
            int[][,] jaggedArray4 = new int[3][,] 
            {
                new int[,] { {1,3}, {5,7} },
                new int[,] { {0,2}, {4,6}, {8,10} },
                new int[,] { {11,22}, {99,88}, {0,9} } 
            };
            // Working through each array in a jagged array
            foreach(int[] innerArr in jaggedArray){
                Console.WriteLine("Inner array length is {0}", innerArr.Length);
            }
            // Accessing a jagged array
            Console.WriteLine(jaggedArray2[0][1]); // 3
            Console.WriteLine(jaggedArray3[2][3]); // 44

            // GENERIC LISTS
            // If you were looking for something more similar to what we call arrays in languages like JS use Generic Lists (or jut Lists)
            // Lists are implementations of linked lists
            // Once you create a list, you are able to freely add and remove things as well as access by index independent of a declared size. This is because lists, just like arrays in JS, are actually just objects with indexed attributes that act as values of an array
            // to use lists, we need to be sure to include class of generics to our project by adding the following to the top:
            // using System.Collections.Generic;

            // Initializing an empty list of Motorcyle Manufacturers
            List<string> bikes = new List<string>();
            // Use the Add function in a similar fashion to push
            bikes.Add("Kawasaki");
            bikes.Add("Triump");
            bikes.Add("BMW");
            bikes.Add("Moto Guzzi");
            bikes.Add("Harley Davidson");
            bikes.Add("Suzuki");

            // Accessing a generic list value is the same as you would an array
            Console.WriteLine(bikes[2]); // => "BMW"
            Console.WriteLine("We currently known of {0} motorcycle manufacturers.", bikes.Count);

            // insert a new item between a specific index
            bikes.Insert(2, "Yamaha");

            // Iterating through a list
            // Using our array of motorcyles from before, we can easily loop thru them w/a C-style for loop
            // This time, however, Count is the attribute for a number of items;
            Console.WriteLine("The current manufacturers we have seen are:");
            for (var i = 0; i < bikes.Count; i++)
            {
                Console.WriteLine("-" + bikes[i]);
            }


            // Removal from Generic List
            // Remove is a lot like JS array pop, but searches for a specified value
            // In this case, we are removing all manufacturers located in Japan
            bikes.Remove("Suzuki");
            bikes.Remove("Yamaha");
            Console.WriteLine("After removing 2 Japanese manufacturers:");
            for (int i = 0; i < bikes.Count; i++)
            {
                Console.WriteLine("-" + bikes[i]);
            }
            // removeAt has no return value
            bikes.RemoveAt(0);
            Console.WriteLine("Our list of motorcycles after removing value at index 0:");
            for (int i = 0; i < bikes.Count; i++)
            {
                Console.WriteLine(bikes[i]);
            }
            
            // The list can be iterated thru using a foreach loop
            Console.WriteLine("Using a foreach loop to iterate:");
            foreach (string manufacturer in bikes)
            {
                Console.WriteLine("-" + manufacturer);
            }

            // DICTIONARY CLASS
            // Dictionary have key-value pairs
            // the type of both key and value must be specified when initializing a dictionary as such: Dictionary<Tkey, Tvalue>
            // it is also a part of the Generic library, so don't forget to include the using statement

            Dictionary <string, string> profile = new Dictionary<string, string>();
            // almost all the methods that exist with lists are the same with Dictionaries
            profile.Add("Name", "Speros");
            profile.Add("Language", "PHP");
            profile.Add("Location", "Greece");
            Console.WriteLine("Instructor Profile");
            Console.WriteLine("Name - " + profile["Name"]);
            Console.WriteLine("From - " + profile["Location"]);
            Console.WriteLine("Favorite Language " + profile["Language"]);
            
            // Iterating thru Dictionaries
            foreach (KeyValuePair<string, string> entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

            // Can clean KeyValuePair by using technique called type inference
            // What type inference does is, is it allows you to not have to directly type the type for the variable, & will cause the variable to INFER what type it'll be based on the 1st value assigned to it

            foreach (var entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

            // BOXING & UNBOXING
            // What do we do when we need to make a collection of different types of data?
            // Boxing: We can construct a list of one data type & that list holds different data types
            // almost all types can be cast as a generic --> object <-- type
                // so you can construct a list of type object, you will be able to hold varying types in one collection
            // be sure to CAST IT BACK TO ITS ORIGINAL TYPE WHEN RETRIEVING ANYTHING (unboxing)

            // box some string data into a variable
            object BoxData = "This is clearly a string.";
            // Make sure it is the type you need before proceeding
            if (BoxData is int)
            {
                Console.WriteLine("I guess we have an integer in the box?"); // shouldn't run
            }
            if (BoxData is string)
            {
                Console.WriteLine("It is totally a string in the box!");
            }
            // the --> is <-- keyword allows us to discern what the real type of an object is when we unbox it, but to actually treat it as that type, we need to actually cast it.
                // unlike conversion casting, unboxing casting doesn't create a new space in memory
                // it just changes how the system references the object
                // with unboxing we use safe explicit casting
            
            // Safe Explicit Casting
            // safe explicit casting uses the --> as <-- keyword
            // if a safe casting fails, unlike an explicit casting (which throws an exception), safe casting simply returns null
            // safe casting can only be used on nullable types. int are non-nullable, and therefore cannot be safe cast

            object ActuallyAString = "a string";
            string ExplicitString = ActuallyAString as string;

            // THIS WON'T WORK
            // object ActuallyInt = 256;
            // int ExplicitInt = ActuallyInt as int;
        }
    }
}
