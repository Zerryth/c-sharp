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

            // sally.Attack(joe);
            // joe.displayInfo();

            Human merlin = new Wizard("Merlin");
            // merlin.displayInfo();
            // (merlin as Wizard).Heal();
            // merlin.displayInfo();
            // (merlin as Wizard).Fireball(joe);

            Human aya = new Ninja("Aya");
            aya.displayInfo();
            // (aya as Ninja).Steal(joe);
            // (aya as Ninja).GetAway().GetAway().GetAway().GetAway();
            // (aya as Ninja).GetAway();

            Human totosai = new Samurai("Totosai");
            // (totosai as Samurai).DeathBlow(aya);
            (totosai as Samurai).Medidate();
        }
    }
}
