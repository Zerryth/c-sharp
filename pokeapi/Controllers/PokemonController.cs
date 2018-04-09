using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokeapi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using pokeapi.Controllers;

namespace pokeapi.Controllers
{
    public class PokemonController: Controller
    {
        Dictionary<string, object> res = new Dictionary<string, object>();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            return View("Pokemon");
        }


        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
            {
                PokeInfo = ApiResponse;

                var Types = new List<string>();
                // in  C#, explicitly tell the JArray, that it's a JArray
                JArray typesJarray = (JArray)PokeInfo["types"];
                foreach (var type in typesJarray)
                {
                    Types.Add(type["type"]["name"].ToString());
                }

                TempData["name"] = PokeInfo["name"];
                TempData["types"] = string.Join(", ", Types); // ea. list element separated by ", "
                TempData["height"] = PokeInfo["height"];
                TempData["weight"] = PokeInfo["weight"];
                TempData["spriteSrc"] = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{pokeid}.png";

            }).Wait();

            return RedirectToAction("Index");
        }
    }
    
}