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
        public IActionResult Create(string type)
        {
            switch (type)
            {
                case "QSection":
                    return Redirect("~/Section/CreateQSection");
                case "Section":
                    return Redirect("~/Section/CreateSection");
                default:
                    return Redirect("~/Home/Index");
            }
        }
        [HttpGet]
        public IActionResult CreateSection()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSection(string text)
        {
            var c = int.Parse(User.Identity.Name);
            Section section = allSections.CreateSection(text,c);
            return Redirect($"~/Section/Section/{section.Id}");
        }



        //[Authorize(Roles = "Admin, Moderator")]


    }
}
