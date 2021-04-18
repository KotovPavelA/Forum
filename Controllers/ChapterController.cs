using Forum.Interfaces;
using Forum.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapter allChapters;
        public ChapterController(IChapter _chapter)
        {
            allChapters = _chapter;
        }
        public IActionResult Index()
        {
            ChapterViewModel model = new ChapterViewModel()
            {
                Chapters = allChapters.GetChapters()
            };
            return View(model);
        }
    }
}
