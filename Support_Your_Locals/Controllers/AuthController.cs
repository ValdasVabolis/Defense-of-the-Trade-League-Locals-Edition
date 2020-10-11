using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support_Your_Locals.Models;
using Support_Your_Locals.Models.ViewModels;

namespace Support_Your_Locals.Controllers
{
    public class AuthController : Controller
    {

        public ServiceDbContext db;

        public AuthController(ServiceDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> SignUp(UserRegisterModel user)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User {Name = user.Name, Surname = user.Surname, BirthDate = user.BirthDate, Email = user.Email};
                await db.Users.AddAsync(newUser);
                await db.SaveChangesAsync();
                return View("Thanks");
            }
            return View();
        }

        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> SignIn(UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                var response = await db.Users.FindAsync(user.Email);
                if (response != null) return View("LoggedIn");
                return View("SignIn", "User not found!");
            }
            else
            {
                return View();
            }
        }

    }
}
