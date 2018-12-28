using LinkHolder.Models;
using LinkHolder.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkHolder.Controllers
{
    public class HomeController : Controller
    {
        private ILinkData _linkData;
        private ITagData _tagData;

        public HomeController(ILinkData linkData, ITagData tagData)
        {
            _linkData = linkData;
            _tagData = tagData;
        }

        public IActionResult Index()
        {
            var links = _linkData.GetAll();

            return View(links);
        }

        [HttpGet]
        public IActionResult CreateTags()
        {
            return View();
        }
        public IActionResult CreateTags(Tag tag)
        {
            Tag newTag = new Tag();
            newTag.Name = tag.Name;

            _tagData.Add(newTag);

            return Content("OK!!");
        }


    }
}
