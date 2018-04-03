public class Vehicle
{
    public int numPassengers;
    public double distance = 0.0;
 
    //Constructors can be overloaded 
    //The first maybe being for a new vehicle
    public Vehicle(int val)
    {
        numPassengers = val;
    }
 
    //The second for preowned with milage already
    public Vehicle(int val, double odo)
    {
        numPassengers = val;
        distance = odo;
    }
 
    //Methods can also be overloaded for handling different parameters
    public int Move(double miles)
    {
        distance += miles;
        return (int)distance;
    }
 
    //If a boolean is included in this version of the method call
    //it may be measuring in km rather than miles.
    public int Move(double miles, bool km)
    {
        //Convert the KM measurement to miles
        if (km == true)
        {
            miles = miles * 0.62;
        }
        distance += miles;
        return (int)distance;
    }
    // //Even a change to a return type will produce a different method
    // public void Move(double miles)
    // {
    //     distance += miles;
    // }
}
