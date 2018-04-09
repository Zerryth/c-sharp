using connecting_to_db.Connectors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace connecting_to_db.Controllers
{
   public class TestController: Controller
   {
       // build out a reference to the db connector
        private MySqlConnector cnx;

        // use the controller constructor to instantiate the cnx every time we hit a route
        public TestController()
        {
            cnx = new MySqlConnector(); // instantiate connector
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Index()
        {
            string query = "SELECT * FROM pokemons";
            // List<Dictionary<string, object>> allPokemon = cnx.Query(query);
            var allPokemon = cnx.Query(query);
            ViewBag.allPokemon = allPokemon;
            // System.Console.WriteLine("****" + allPokemon);
            foreach (var entry in allPokemon)
            {
                System.Console.WriteLine("Name: " + entry["name"]);
                System.Console.WriteLine("Type: " + entry["type"]);
            }
            return View("Test");
        }

        [HttpPost]
        [Route("/addPokemon")]
        public IActionResult AddPokemon(string name, string type)
        {
            System.Console.WriteLine(name);
            System.Console.WriteLine(type);
            string query = $"INSERT INTO pokemons (name, type, created_at, updated_at) VALUES ('{name}','{type}', NOW(), NOW())";
            cnx.Execute(query);
            return RedirectToAction("Index");
        }
   }
}