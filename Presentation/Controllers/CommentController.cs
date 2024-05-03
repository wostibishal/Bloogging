using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
