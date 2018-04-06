using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio.Controllers
{
    public class ProjectController: Controller
    {
        [HttpGet]
        [Route("project")]
        public IActionResult Project()
        {
            return View("Project");
        }
    }
}