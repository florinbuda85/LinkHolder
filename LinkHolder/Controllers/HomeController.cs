using LinkHolder.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkHolder.Controllers
{
    public class HomeController : Controller
    {
        private ILinkData _linkData;

        public HomeController(ILinkData linkData)
        {
            _linkData = linkData;
        }

        public IActionResult Index()
        {
            var links = _linkData.GetAll();

            return View(links);
        }
    }
}
