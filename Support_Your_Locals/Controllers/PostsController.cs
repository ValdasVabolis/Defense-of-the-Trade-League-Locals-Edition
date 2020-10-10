using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Support_Your_Locals.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public IActionResult New()
        {
            return View();
        }
        
        
    }
}
