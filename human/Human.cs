using System;

namespace human
{
    public class Human
    {
        public string name;
        public int strength, intelligence, dexterity, health;
        public Human(string name)
        {
            // Give a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.
            // When an object is constructed from this class it should have the ability to pass a name
            this.name = name;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
            this.health = health;
        }

        // Now add a new method called attack, which when invoked, should attack another Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker).
        public Human Attack(Human attackTarget)
        {
            attackTarget.health -= 5 * strength;
            Console.WriteLine($"{attackTarget.name} was attacked. Health is now at {attackTarget.health}");
            return this;
        }
        // (Optional) Change the last function to accept any object and just make sure it is of type Human before applying damage. Hint you may need to refer back to the Boxing/Unboxing tab!
        public Human Attack(object attackTarget)
        {
            if (attackTarget is Human)
            {
                Human temp = attackTarget as Human;
                temp.health -= 5 * strength;
                temp.displayInfo();
            }
            else
            {
                Console.WriteLine("You can only attack humans!");
            }
            return this;
        }

        public Human displayInfo()
        {
            Console.WriteLine($"name: {this.name}, strength: {strength}, intelligence: {intelligence}, dexterity: {dexterity}, health: {health}");
            return this;
        }
    }
}