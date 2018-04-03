using System;

namespace human
{
    public class Ninja: Human
    {
        public Ninja(string name): base(name)
        {
            this.dexterity = 175;
        }
        // attacks object & increase health by 10
        public Ninja Steal(object stealTarget)
        {
            Attack(stealTarget);
            displayInfo();
            return this;
        }

        // ninjas should have a GetAway method, which decreases health by 15
        public Ninja GetAway()
        {
            health -= 15;
            Console.WriteLine($"{name} got used GetAway.");
            displayInfo();
            return this;
        }
    }
}