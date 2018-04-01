using System;

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
                System.Console.WriteLine(rand.Next(2,8));
            }
        }
    }
}
