using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        //default/index/12345?a=1&b=2&c3 <summary>
        // default/index/12345?c=1
        // default/index/12345?c=1&a=3

        public IActionResult Index(int? id, int a=10, int b=20, int c=30)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //pass a value from controller to view
            ViewBag.id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

            return View();
        }
    }
}
