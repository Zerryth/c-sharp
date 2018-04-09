using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generics;
using Newtonsoft.Json;

namespace asp_net_core_getting_started.Controllers
{
    public class YourControllerAPIExampleController: Controller
    {
        [HttpGet]
        [Route("pokemon/{pokemonId}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            // other code
            // even though GetPokemonDataAsync is asynchronous, we can fource it to run synchronously by calling the .Wait() method available to all asynchronous methods
            // when we use .Wait() with aysnc methods, we lose the benefits of asynchronous processing.
            // This is acceptable when our main thread needs the async operation to complete before it can continue in any case
        }
    }
}