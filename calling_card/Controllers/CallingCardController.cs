using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calling_card
{
    public class CallingCardController: Controller
    {
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World";
        }

        [HttpGet]
        [Route("{firstName}/{lastName}/{age}/{favoriteColor}")]
        public JsonResult DisplayHuman(string firstName, string lastName, int age, string favoriteColor)
        {
            return Json(new Human(firstName, lastName, age, favoriteColor));
        }

        
    }
}