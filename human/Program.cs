using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a base Human class with five attributes: name, strength, intelligence, dexterity, and health.
            Human joe = new Human("Joe"); 
            Human sally = new Human("Sally", 5, 5, 5, 150);

            sally.Attack(joe);
            joe.displayHealth();
        }
    }
}
