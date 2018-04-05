using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace rapper_api
{
    public class ArtistController: Controller
    {
        [HttpGet]
        [Route("")]
        public string Home()
        {
            return "Yoyoyo! You made it home.";
        }
        
    }
}