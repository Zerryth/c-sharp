namespace classes_notes
{
    public class Vehicle
    {
        public int numPassenger;
        public double distance;

        // Constructors can be overloaded
        // Constructor - method that will run a codeblock whenever you're building an object of this class
        // 1st version for a new vehicle
        public Vehicle(int val = 0) // accecibility classname | setting default parameter for passenger
        {
            numPassenger = val;
            distance = 0.0;
        }
        
        //The 2nd for preowned with milage already
        public Vehicle(int val, double odo)
        {
            numPassenger = val;
            distance = odo;
        }

        // Methods can also be overloaded for handling different parameters
        public int Move(double miles)
        {
            distance += miles;
            return (int)distance;
        }

        // If a boolean is included in this version of the method call
        // it may be measuring in km rather than miles
        // public int Move(double miles, bool km)
        // {
        //     if (km == true)
        //     {
        //         miles *= .62;
        //     }
        //     distance += miles;
        //     return (int) distance;
        // }

        // Even a change to a return type will produce a different method
        // public void Move(double miles)
        // {
        //     distance += miles;
        // }

        // Can improve and make code DRYer by making overloaded version call the 1st version
        public int Move(double miles, bool km)
        {
            // Conver to the KM measurement to miles
            if (km == true)
            {
                miles *= .62;
            }
            return Move(miles);
        }
    }
}