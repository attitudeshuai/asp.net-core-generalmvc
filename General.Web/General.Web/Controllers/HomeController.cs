using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using General.Web.Models;
using General.Bussiness.ISerivces;
using General.Core;

namespace General.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPersonService personSerivce;
        public HomeController(IPersonService _personSerivce)
        {
            personSerivce = _personSerivce;
        }
        public IActionResult Index()
        { 
            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
