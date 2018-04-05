using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace rendering_views_intro.Controllers
{
    public class HelloController: Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
            //OR
            // return View("Index");
            // Both of these returns will render the same view (you only need one!)
        }
    }
}