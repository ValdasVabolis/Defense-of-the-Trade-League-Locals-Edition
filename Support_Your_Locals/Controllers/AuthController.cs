using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support_Your_Locals.Models;
using Support_Your_Locals.Models.Repositories;
using Support_Your_Locals.Models.ViewModels;

namespace Support_Your_Locals.Controllers
{
    public class AuthController : Controller
    {

        private IServiceRepository repository;
        public AuthController(IServiceRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string email, string name, string surname, DateTime date)
        {
            return Content("Sending: " + email +" "+ name+ " "+ surname+ " " + date.ToString());
        }
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string email)
        {
            return Content("Sending: " + email);
        }
    }
}
