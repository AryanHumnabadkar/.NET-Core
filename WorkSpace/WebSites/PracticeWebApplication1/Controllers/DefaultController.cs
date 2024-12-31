using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
