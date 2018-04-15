using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DependencyInjectionSample.Models;
using Microsoft.Extensions.Configuration;

namespace DependencyInjectionSample.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;
        private person per;
        
        public HomeController(IConfiguration configuration)
        {
            per = configuration.Get<person>();
        }
        public IActionResult Index()
        {
            
            return Content(per.Name+per.Hobby);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }
    }
}
