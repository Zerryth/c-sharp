using System;

namespace human
{
    public class Wizard: Human
    {
        public Wizard(string name): base(name)
        {
            this.intelligence = 25;
            this.health = 50;
        }
        public Wizard Heal()
        {
            health += intelligence * 10;
            return this;
        }
        //deal 20 - 50 damage to target
        public Wizard Fireball(object fireballTarget)
        {
            if (fireballTarget is Human)
            {
                Random rand = new Random();
                int damage = rand.Next(20, 51);
                Console.WriteLine("fireball damage: {0}", damage);
                Human temp = (Human)fireballTarget;
                temp.health -= damage;
                temp.displayInfo();
            }
            else
            {
                Console.WriteLine("You can only fireball humans!");
            }
            return this;
        }
    }
}