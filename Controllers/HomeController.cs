using Forum.Interfaces;
using Forum.Models;
using Forum.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllSections allSections;

        public HomeController(ILogger<HomeController> logger, IAllSections _allSections)
        {
            _logger = logger;
            allSections = _allSections;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var a = new SectionsListViewModel()
            {
                Sections = allSections.GetAllSectionsForList.ToList()
            };
            return View(a);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
