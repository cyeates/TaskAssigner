using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public TagsController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public JsonResult GetTags()
        {
            return Json(_tagRepository.GetTags().Select(t => t.Name).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
