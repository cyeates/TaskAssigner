using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TaskAssigner.Models;
using TaskAssigner.Models.Repositories;

namespace TaskAssigner.Controllers
{ 
    public class DevelopersController : Controller
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly ITagRepository _tagRepository;

        public DevelopersController(IDeveloperRepository developerRepository, ITagRepository tagRepository)
        {
            _developerRepository = developerRepository;
            _tagRepository = tagRepository;
        }


        public ViewResult Index()
        {
            var developers = _developerRepository.GetDevelopers();
            return View(developers);
        }


        public ActionResult Create()
        {
            var developer = new Developer();
            return View(developer);
        } 


        [HttpPost]
        public ActionResult Create(Developer developer, string tagsString)
        {
            AddTagsToDeveloper(developer, tagsString);

            if (ModelState.IsValid)
            {
                _developerRepository.Add(developer);
                _developerRepository.Save();
                return RedirectToAction("Index");  
            }

            return View(developer);
        }

        private Developer AddTagsToDeveloper(Developer developer, string tagsString)
        {
            var tagNames = Regex.Split(tagsString, ", ");
            foreach (string tagName in tagNames.Where(t => !String.IsNullOrEmpty(t)))
            {
                var tag = _tagRepository.GetByName(tagName);
                developer.Tags.Add(tag);
            }
            return developer;
        }
        
        
    }
}