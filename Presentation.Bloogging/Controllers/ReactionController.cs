using Microsoft.AspNetCore.Mvc;

namespace Presentation.Bloogging.Controllers
{
    public class ReactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
