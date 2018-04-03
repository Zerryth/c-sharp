using System;
using System.Collections.Generic;
using System.Linq;

namespace linq // LINQ - Language Integrated Queries
{
    public interface ITest
    {
        
    }
    class Program
    {
        class Product {
            public string Name;
            public string Category;
            public double Price;
        }
        // NOTES
        // LINQ allows you to work with any dataset as if you were using SQL queries
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product { Name = "Jeans", Category = "Clothing", Price = 24.7 },
                new Product { Name = "Socks", Category = "Clothing", Price = 8.12 },
                new Product { Name = "Scooter", Category = "Vehicle", Price = 99.99 },
                new Product { Name = "Skateboard", Category = "Vehicle", Price = 24.99 }
            };

            // With this dataset, we can sort all items by price, then get exclusively the Name and price field using LINQ.
            // We must make sure to include the LINQ namespace in our code and from there can implement a query using the LINQ keywords

            var foundProducts = from match in products
                                                orderby match.Price descending
                                                select new { match.Name, match.Price };

            // we have created a variable foundProducts that can be iterated through and contains anonymous objects holding Name and Price that are sorted by Price.

            // JOIN
            // Join accepts 4 arguments:
                // 2nd collection we want to join with
                // lambda function that defines how the products from the 1st collections are compared
                // lambda function that defines how the products from the 2nd collection are compared
                // lambda funciton that defines how the matching values are combined
            
            List<string> Food = new List<string> 
            {
                "apple",
                "banana",
                "carrot",
                "fudge",
                "tomato"
            };
            List<string> Adjective = new List<string>
            {
                "tasty",
                "capital",
                "best",
                "typical",
                "flavorful",
                "toothsome"
            };

            // This Join looks at each foodItem and combines it with each adjective that has the same first character
            List<string> Combo = Food.Join(Adjective,
                                            foodItem => foodItem[0],
                                            adjective => adjective[0],
                                            (foodItem, adjective) =>
                                            {
                                                return adjective + " " + foodItem;
                                            }).ToList();
        }
    }
}

// LIST OF LINQ KEYWORDS

//Clause: Description

//from: Specifies a data source and a range variable (similar to an interation variable)
// where: Filters source elements based on one or more Boolean expressions separated by logical AND and OR operators ( && or || )
// select: Specifies the type and shape that the elements in the returned will have when the query is executed
// group: Groups query results according to a specified key value
// into: Provides an identifier that can serve as a reference to the results of a join, group, or select clause
// orderby: Sorts query results in ascending or descending order based ont he default comparer for the element type
// join: Joins two data sources based on an equality comparison between 2 specified matching criteria
// let: introduces a range variable to store sub-expression results in a query expression
// in: contextual keyword in a JOIN clause
// on: contextual keyword in a JOIN clause
// equals: contextual keyword in a JOIN clause
// by: contetual keyword in a GROUP clause
// ascending: contextual keyword in an ORDERBY clause
// descending: contextual keyword in an ORDERBY clause

