using Forum.Interfaces;
using Forum.Models;
using Forum.Models.ViewModel;
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
        public SectionController(IAllSections _allSections)
        {
            allSections = _allSections;
        }
        [HttpGet]
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
        [HttpPost]
        public IActionResult Section(int id)
        {
            
            return View();
        }


    }
}
