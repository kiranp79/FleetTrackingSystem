using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KeepTrack.Models;
using Microsoft.AspNetCore.Http;

namespace KeepTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Registration registration = new Registration();
            return View(registration);
        }
     
        public IActionResult AddAgent()
        {
            FleetData data = new FleetData();
            return View(data);
        }

        public IActionResult Agents()
        {
            FleetData fd = new FleetData();
            return View(fd);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
