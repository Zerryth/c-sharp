using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {

    [Route("artists/")]
    public class ArtistController : Controller {

        private List<Artist> allArtists;
        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("/instructions")]
        // [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        // Create a route for /artists that returns all artists as JSON
        [Route("")]
        [HttpGet]
        public JsonResult ShowAllArtists()
        {
            return Json(allArtists);
        }

        // Create a route /artists/name/{name} that returns all artists that match the provided name
        [Route("name/{name}")]
        [HttpGet]
        public JsonResult GetArtistsByName(string name)
        {
            var artistsWithName = allArtists.Where(artist => artist.ArtistName == name);
            return Json(artistsWithName);
        }

        // Create a route /artists/realname/{name} that returns all artists who real names match the provided name
        [Route("realname/{realName}")]
        [HttpGet]
        public JsonResult GetArtistsByRealName(string realName)
        {
            var artistsWithRealName = allArtists.Where(artist => artist.RealName == realName);
            return Json(artistsWithRealName);
        }

        // Create a route /artists/hometown/{town} that returns all artists who are from the provided town
        [Route("hometown/{town}")]
        [HttpGet]
        public JsonResult GetArtistsByTown(string town)
        {
            var artistsFromTown = allArtists.Where(artist => artist.Hometown == town);
            return Json(artistsFromTown);
        }

        // Create a route /artists/groupid/{id} that returns all artists who have a GroupId that matches id
        [Route("groupid/{id}")]
        [HttpGet]
        public JsonResult GetArtistsByGroupId(int id)
        {
            var artistsWithGroupId = allArtists.Where(artist => artist.GroupId == id);
            return Json(artistsWithGroupId);
        }
        
    }
}