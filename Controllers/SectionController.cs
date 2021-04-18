using Forum.Interfaces;
using Forum.Models;
using Forum.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class SectionController : Controller
    {
        private readonly IAllSections allSections;
        private readonly IAnswer allAnswers;
        public SectionController(IAllSections _allSections, IAnswer _answer)
        {
            allSections = _allSections;
            allAnswers = _answer;
        }
        public IActionResult Section(int id)
        {
            var s = allSections.FindSectionById(id);
            SelectedSectionViewModel model = new SelectedSectionViewModel()
            {
                Section = s
            };

            if (s == null)
            {
                QSection qs = allSections.FindQSectionById(id);
                model.Section = qs;
                model.Variants = qs.Variants;
                model.UniqUsers = qs.UniqUsers;
            }
            return View(model);
        }


        [Authorize]
        public IActionResult RecordAnswer(int id)
        {
            int SectionId = allAnswers.AddVoteToAnswer(id);

            return Redirect($"~/Section/Section/{SectionId}");
        }
        [Authorize]
        public IActionResult Create(string type, int id)
        {
            switch (type)
            {
                case "QSection":
                    return RedirectToAction("CreateQSection", "Section", new { id = id });
                case "Section":
                    return RedirectToAction("CreateSection", "Section", new { id = id });
                default:
                    return Redirect("~/Home/Index");
            }
        }
        [HttpGet]
        public IActionResult CreateSection(int id)
        {

            return View(id);
        }
        [HttpPost]
        public IActionResult CreateSection(int id,string text)
        {
            var user = int.Parse(User.Identity.Name);
            Section section = allSections.CreateSection(id,text,user);
            return Redirect($"~/Section/Section/{section.Id}");
        }

        [HttpGet]
        public IActionResult CreateQSection(int id)
        {

            return View(id);
        }
        [HttpPost]
        public IActionResult CreateQSection(int id, string text)
        {
            var user = int.Parse(User.Identity.Name);
            QSection section = allSections.CreateQSection(id, text, user);
            return Redirect($"~/Section/Section/{section.Id}");
        }



        //[Authorize(Roles = "Admin, Moderator")]


    }
}
