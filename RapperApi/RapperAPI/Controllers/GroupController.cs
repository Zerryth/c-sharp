using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    [Route("groups/")]
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        // Create a route /groups that returns all groups as JSON
        [Route("")]
        [HttpGet]
        public JsonResult ShowAllGroups()
        {
            return Json(allGroups);
        }

         // (Optional) Add an extra boolean parameter to the group routes called displayArtists that will include members for all Group JSON responses

        // [Route("name/{groupName}/{showMembers:bool}")]
        // [HttpGet]
        // public JsonResult GetByNameAndShowMembers(string groupName, bool showMembers)
        // {
        //     var groupsWithName = allGroups.Join(allArtists,
        //                                         group => group.Id,
        //                                         artist => artist.GroupId,
        //                                         (group, artist) =>
        //                                         {
        //                                             return new { Id = group.Id, Group = group.GroupName, group.Members };
        //                                         })
        //                                         .Where(g => g.Group == groupName);
        //     return Json(groupsWithName);                                       
        // }

        // Create a route /groups/name/{name} that returns all groups that match the provided name
        [Route("name/{groupName}")]
        [HttpGet]
        public JsonResult GetGroupsByName(string groupName)
        {
            var groupsWithName = allGroups.Where(group => group.GroupName == groupName);
            return Json(groupsWithName);
        }


        // Create a route /groups/id/{id} that returns all groups with the provided Id value
        [Route("id/{id}")]
        [HttpGet]
        public JsonResult GetGroupsById(int id)
        {
            var groupsWithId = allGroups.Where(group => group.Id == id);
            return Json(groupsWithId);
        }
       

    }
}