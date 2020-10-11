using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Support_Your_Locals.Models;

namespace Support_Your_Locals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> skelbimai = new List<string>();
            skelbimai.Add("Kepejas");
            skelbimai.Add("Auto-mechanikas");
            skelbimai.Add("Auklyte");
            skelbimai.Add("Grindu ploveja");
            //ViewData["skelbimai"] = skelbimai;

            return View(skelbimai);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Add_advertise()
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
