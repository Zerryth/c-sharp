using System;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            // RANDOM ARRAY
            // Create a function called RandomArray() that returns an integer array
            // MakeRandomArray(rand);
            
            // TossCoin(rand);

            // TossMultipleCoins(5, rand);

            string[] namesArray = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            ShuffleNames(namesArray, rand);
        }
        public static int[] MakeRandomArray(Random rand)
        {
            int[] randomArray = new int[10];

            int sum = 0;
            int min = 25;
            int max = 5;
            for (int i = 0; i < 10; i++)
            {
                // Place 10 random integer values between 5-25 into the array
                randomArray[i] = rand.Next(5, 26);
                sum += randomArray[i];
                if (randomArray[i] < min)
                {
                    min = randomArray[i];
                }
                if (randomArray[i] > max)
                {
                    max = randomArray[i];
                }
                Console.WriteLine(randomArray[i]);
            }
            Console.WriteLine($"Min: {min}, Max: {max}, Sum: {sum}");
            return randomArray;
        }

        // Create a function called TossCoin() that returns a string
        public static string TossCoin(Random rand)
        {
            // Have the function print "Tossing a Coin!"
            Console.WriteLine("Tossing a Coin!");
            string results = "";
            // Randomize a coin toss with a result signaling either side of the coin 
            int flip = rand.Next(0, 2);
            // Have the function print either "Heads" or "Tails"
            if (flip == 0)
            {
                results = "Tails";
            }
            else
            {
                results = "Heads";
            }
            Console.WriteLine(results);
            return results;
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double
        public static double TossMultipleCoins(int num, Random rand)
        {
            int heads = 0;
            int tails = 0;
            for (int i = 0; i < num; i++)
            {
                string coinToss = TossCoin(rand);
                if (coinToss == "Tails")
                {
                    tails++;
                }
                else 
                {
                    heads++;
                }
                Console.WriteLine($"TossCoin() returned: {coinToss}. Current tails: {tails} & heads: {heads}");
            }
            // Have the function return a Double that reflects the ratio of head toss to total toss
            double ratio = (double)heads / num;
            Console.WriteLine(ratio);
            return ratio;
        }

        // Names
        // Build a function Names that returns an array of strings
        // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        
        // Shuffle the array and print the values in the new order
        public static string[] ShuffleNames(string[] namesArray, Random rand)
        {
            for (int i = 0; i < namesArray.Length; i++)
            {
                int randomIdx = rand.Next(0, namesArray.Length-1);
                string temp = namesArray[i];
                namesArray[i] = namesArray[randomIdx];
                namesArray[randomIdx] = temp;
            }
            // print shuffled array
            for (int i = 0; i < namesArray.Length; i++)
            {
                Console.WriteLine(namesArray[i]);
            }
            return namesArray;
        }   
    }
}
