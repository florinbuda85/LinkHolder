using Microsoft.AspNetCore.Mvc;

namespace LinkHolder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
