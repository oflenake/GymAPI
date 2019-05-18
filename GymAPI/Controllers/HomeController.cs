using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymAPI.Interface;
using GymAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    public class HomeController : Controller
    {
        private ISchemeMaster _schemeMaster;

        public HomeController(ISchemeMaster schemeMaster)
        {
            _schemeMaster = schemeMaster;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = "Gym Application system is used to manage Vision-Dream App processes.";
            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your contact page.";
            ViewData["Message"] = "Contact us on: http://gymapp.vision-dream.local.";
            return View();
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
