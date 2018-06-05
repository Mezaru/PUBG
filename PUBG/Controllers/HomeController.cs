using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PUBG.Models;

namespace PUBG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiCalls api;

        public HomeController(ApiCalls api)
        {
            this.api = api;
        }

        public IActionResult Index()
        {
            api.GetPlayerAsync("pc-eu", "Mezaru");
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
