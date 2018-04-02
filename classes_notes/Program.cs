using System;

namespace classes_notes
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myCar = new Vehicle(2); // new means clear out some memory space, we'll be making a new object here
            Console.WriteLine(myCar.numPassenger);
            myCar.Move(4.5);

            Vehicle myBike = new Vehicle(1);
            Console.WriteLine(myBike.numPassenger);
            myBike.Move(1.3);

            Console.WriteLine("My bike went {0} miles & my car went {1} miles.", myBike.distance, myCar.distance);
        }
    }
}
