using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGetAttribute]

        [HttpGet]
        [Route("index")] // does NOT need leading slash. Matches localhost:5000/index
        public string Index()
        {
            return "Hello World!";
        }

        // A POST method
        [HttpPost]
        [Route("")]
        public IActionResult Other()
        {
            // Return a view (We'll learn how soon!)
        }

        [HttpGet]
        [Route ("template/{Name}")] // method expects to receive param thru URL -- breaks if no param
        public IActionResult Method(string Name)
        {
            // Method body
        }

        [HttpGet]
        [Route("myjsonroute")]
        public JsonResult Example()
        {
            // The Json method convert the object passed to it into JSON
            return Json(SomeCSharpObject); 
            // The Json() method will accept any type of object for serialization, from simple values like ints to complex objects
        }

        [HttpGet]
        [Route("displayint")]
        public JsonResult DisplayInt()
        {
            return Json(34);
        }

        [HttpGet]
        [Route("displayhuman")]
        public JsonResult DisplayHuman()
        {
            return Json(new Human());
        }

        // ANONYMOUSE OBJECTS
        // If we wnat to return a group of values as JSON, we have to write a class definition with appropriate fields to contain the data. But what if a different route needed to return a slightly different number of values or values of different types? We'd need to write an additional class for each configuration of values. Instead, we can use what are known as -->anonymous objects<--.
        // Anonymous objects can be instantiated as a grouping of property names and values, without confirming to any class.

        // Here we construct an anonymous object with FirstName, LastName, and Age properties:

        [HttpGet]
        [Route("displayint")]
        public JsonResult DisplayInt()
        {
            var AnonObject = new {
                                FirstName = "Raz",
                                LastName = "Aquato",
                                Age = 10
                            };
            return Json(AnonObject);
        }

        // Anonymous objects aren't just used to format information for JSON responses, thye can be used anywhere you need them.
        // They are best used in moderation, however, defining classes provides much better code readability in most situations
        // If you ever find yourself constructing multiple anonymous objects with the same set of properties, you definitely need a class!
    }
}
