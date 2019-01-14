using LinkHolder.Models;
using LinkHolder.Services;
using LinkHolder.Util;
using LinkHolder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LinkHolder.Controllers
{
    public class HomeController : Controller
    {
        private ILinkData _linkData;
        private ITagData _tagData;

        public  static List<int> joinedTags;

        public HomeController(ILinkData linkData, ITagData tagData)
        {
            _linkData = linkData;
            _tagData = tagData;
        }

        public IActionResult Index()
        {
            var links = _linkData.GetAll();

            joinedTags = null;

            return View(links);
        }


        public IActionResult ListTags(int id)
        {

            if (joinedTags is null)
                joinedTags = new List<int>();

            joinedTags.Add(id);

            var links = _linkData.GetAllByTag(joinedTags);
            var tags = _tagData.GetTagsByIds(joinedTags);
           

            var model = new HomeListTags();
            model.Links = links;
            model.JoinedTags = tags;

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateLinks()
        {
            var model = new HomeIndexViewModel();

            var allTags = _tagData.GetAll().Select(vm => new CheckBoxItem()
            {
                id = vm.Id,
                Title = vm.Name,
                IsChecked = false
            }).ToArray();

            model.Link = new Link();
            model.AllPosibleTags = allTags;


            return View(model);
        }
        public IActionResult CreateLinks(HomeIndexViewModel model)
        {
            Link newLink = new Link();
            newLink.LastVisit = System.DateTime.Now;
            newLink.TimesClicked = 0;
            newLink.Title = TitleGetter.GetTitle(model.Link.Content);
            newLink.Content = model.Link.Content;


            newLink = _linkData.Add(newLink);
            newLink.LinkTags = new System.Collections.Generic.List<LinkTag>();

            foreach (var tag in model.AllPosibleTags)
            {
                if (tag.IsChecked)
                {
                    newLink.LinkTags.Add(new LinkTag()
                    {
                        LinkId = newLink.Id,
                        TagId = tag.id
                    });
                }
            }

            _linkData.Update(newLink);


            return Content("Link created");
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

            //return Content("OK!!");
            return this.TellMessage(new InformationMessage
                {
                    Content = "The tag was created!",
                    Title = "New tag"
                });
        }



        public IActionResult TellMessage(InformationMessage im)
        {
            return View("TellMessage", im);
        }


    }
}
