using System;

namespace calling_card
{
   public class Human
   {
       public string FirstName;
       public string LastName;
       public int Age;
       public string FavoriteColor;

       public Human(string firstName, string lastName, int age, string color)
       {
           FirstName = firstName;
           LastName = lastName;
           Age = age;
           FavoriteColor = color;
       }
       
   }
}