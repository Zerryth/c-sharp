using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generics;
using Newtonsoft.Json;

namespace asp_net_core_getting_started
{
    public class WebRequest
    {
        // the 2nd parameter is a function that returns a Dictionary of string keys and object values
        // If API returned an array as its top level collection the parameter type would be "Action"
        public static async Task GetPokemonDataAsync(int PokeId, Action<Dictionary<string, object>> Callback)
        {
            // Create a temporary HttpClient connection
            using(var Client = new HttpClient()) // when lifetime of an IDisposable object is limited to a single method, you should declare and instantiate it in a using statement. The using statement calls the Dispose method on the object in the correct way, and it causes the object itself to go out of scope as soon as Dispose is called. Within the using block, the object is read-only and cannot be modified or reassigned
            {
                try
                {
                    // .BaseAddress
                    // Gets or sets the base address of Uniform Resource Identifier (URI) of the Internet resource used when sending requests.
                    Client.BaseAddress = new Uri ($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    // Sends a GET request to the specified Uri as an asynchronous operation.
                    HttpResponseMessage Response = await Client.GetAsync(""); // make actual API call
                    Response.EnsureSuccessStatusCode(); // throw error if not successful
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // read response as a string

                    // Then parse the result into JSON and convert to a dictionary that we can use
                    // DeserializeObject will parse only the top level object, depending ont he API, you may need to dig deeper and continue deserializing
                    Dictionary<string, object> JsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringResponse);

                    // Finally, execute our Callback, passing it the response we got
                    Callback(JsonResponse);
                }
                catch (HttpRequestException e)
                {
                    
                    throw;
                }
            }
        }
    }
}

// Our regular methods all run on a single thread, meaning that each method must finish its execution before another one can start.
// Asynchronous methods open a new thread when they are executed, allowing them to run simutaneously to our main thread or other asynchronous methods
// All asynchronous methods must return a Task object, which represents the asynchronouse process that is still running
// the -->await<-- keyword is used to force the main thread to wait until a Task is finished executing

// With this or any similar method, we can call it from our controllers, using a lambda callback to handle the return