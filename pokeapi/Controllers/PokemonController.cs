using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pokeapi.Models;
using Newtonsoft.Json.Linq;

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

        // [HttpGet]
        // [Route("pokemon/{pokeid}")]
        // public IActionResult QueryPoke(int pokeid)
        // {
        //     var PokeInfo = new Dictionary<string, object>();
        //     WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
        //     {
        //         PokeInfo = ApiResponse;
        //     }).Wait();
        //     Console.WriteLine("****************" + PokeInfo);
        //     Console.WriteLine("tes");
            
        //     return View("Pokemon");
        // }

        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public JsonResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
            {
                PokeInfo = ApiResponse;
                // Console.WriteLine(PokeInfo["forms"]);
                // Console.WriteLine("**********");

             
               
            }).Wait();
            
            
            
            return Json(res);
        }
    }
}