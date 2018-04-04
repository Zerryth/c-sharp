using System;
using System.Collections.Generic;
using DbConnection;

namespace crud_with_mysql
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
            // Create();
            // Update();
            // Delete();
        }

        // Build a Read function that displays all current users information when the app starts and after every insert
        public static void Read()
        {
            List<Dictionary<string, object>> users = DbConnector.Query("Select * from Users");
            Console.WriteLine();
            foreach(Dictionary<string, object> user in users)
            {
                foreach(var entry in user)
                {
                    Console.WriteLine(entry);
                }
            }
        }

        // Build a "create" function that accepts input and creates a new User row
        public static void Create()
        {
            // listen for console input
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string favoriteNumber = Console.ReadLine();
            // insert values returned from input into the sql query
            DbConnector.Execute($"INSERT INTO Users (FirstName, LastName, FavoriteNumber) VALUES ('{firstName}', '{lastName}', {favoriteNumber})");
            // display info
            Read();
        }

        // (Optional) Build an Update function that when you specify a User Id, it will allow you to update all prompted rows
        public static void Update()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string favoriteNumber = Console.ReadLine();
            string id = Console.ReadLine();
            DbConnector.Execute($"UPDATE Users SET FirstName='{firstName}', LastName='{lastName}', FavoriteNumber='{favoriteNumber}' WHERE id = {id}");
            Read();
        }

        // (Optional) Build a Delete function that will remove a user with the ID being specified
        public static void Delete()
        {
            string id = Console.ReadLine();
            DbConnector.Execute($"DELETE FROM Users WHERE id = {id}");
            Read();
        }
    }
}
