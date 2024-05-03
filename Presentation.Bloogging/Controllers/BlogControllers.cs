using Microsoft.AspNetCore.Mvc;

namespace Presentation.Bloogging.Controllers
{
    public class BlogControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
