// using connecting_to_db.Connectors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using connecting_to_db.Models;
using connecting_to_db.Factories;

namespace connecting_to_db.Controllers
{
   public class TestController: Controller
   {
       // build out a reference to the db connector
        private readonly PokemonFactory pokemonFactory;

        // use the controller constructor to instantiate the cnx every time we hit a route
        public TestController()
        {
            pokemonFactory = new PokemonFactory(); // instantiate connector
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Index()
        {
            ViewBag.allPokemon = pokemonFactory.GetAllPokemon();
            // System.Console.WriteLine("****" + allPokemon);
            foreach (var entry in ViewBag.allPokemon)
            {
                System.Console.WriteLine("Name: " + entry["name"]);
                System.Console.WriteLine("Type: " + entry["type"]);
            }
            return View("Test");
        }

        [HttpPost]
        [Route("/addPokemon")]
        public IActionResult AddPokemon(Pokemon pokemon)
        {
            System.Console.WriteLine(pokemon.name);
            System.Console.WriteLine(pokemon.type);
            pokemonFactory.AddPokemon(pokemon);
            return RedirectToAction("Index");
        }
   }
}