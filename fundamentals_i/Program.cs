using System;

namespace fundamentals_i
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Loop that prints all values from 1-255
            for (int i = 1; i <= 255; i++)
            {
             Console.WriteLine(i);   
            }

            // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            for (int i = 1; i <= 100; i++)
            {
                if ( ((i % 3 == 0) && (i % 5 != 0)) || ((i % 5 == 0) && (i % 3 != 0)) )
                {
                    Console.WriteLine(i);
                }
            }

            // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0 && i % 3 != 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 5 == 0 && i % 3 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }

            // (Optional) If you used modulus in the last step, try doing the same without using it. Vice-versa for those who didn't!
            void fizzBuzz(int fizz, int buzz, int fizz_buzz, int counter)
            {
                if (fizz_buzz == 15)
                {
                    Console.WriteLine("FizzBuzz");
                    fizz = 0; buzz = 0; fizz_buzz = 0;
                }
                else if (fizz == 3)
                {
                    Console.WriteLine("Fizz");
                    fizz = 0;
                }
                else if (buzz == 5)
                {
                    Console.WriteLine("Buzz");
                    buzz = 0;
                }
                if (counter < 100)
                {
                    fizzBuzz(++fizz, ++buzz, ++fizz_buzz, ++counter);
                }
            }
            int main()
            {
                fizzBuzz(1,1,1,1);
                return 0;
            }
            main();

            // (Optional) Generate 10 random values and output the respective word, in relation to step three, for the generated values
            Random randomObject = new Random();
            for (int i = 0; i < 10; i++)
            {
                int randomized = randomObject.Next(1,100); 
                Console.WriteLine("The random number is {0}.", randomized);

                if (randomized % 3 == 0 && randomized % 5 != 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (randomized % 5 == 0 && randomized % 3 != 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (randomized % 3 == 0 && randomized % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
        }
    }
}
