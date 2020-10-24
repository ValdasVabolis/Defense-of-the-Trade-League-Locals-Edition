using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Support_Your_Locals.Models;

namespace Support_Your_Locals.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceDbContext db;
        
        public IActionResult New()
        {
            List<string> days = new List<string>();
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");
            days.Add("Sunday");

            return View(days);
        }

        [HttpPost]
        public JsonResult Create(string jsonData)
        {
            string resp = "received: " + jsonData;
            return Json(resp);
        }
        
    }
}
