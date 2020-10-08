using Microsoft.AspNetCore.Mvc;
using Support_Your_Locals.Models;

namespace Support_Your_Locals.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SignUp(UserRegisterModel user)
        {
            if (ModelState.IsValid)
            {
                return View("Index", user);
            }
            else
            {
                return View();
            }
        }


        public ViewResult SignIn()
        {
            return View();
        }
    }
}
