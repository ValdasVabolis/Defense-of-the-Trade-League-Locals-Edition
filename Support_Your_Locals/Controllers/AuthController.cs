using System;
using System.Diagnostics;
using System.Linq;
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
        private ServiceDbContext context;
        public AuthController(IServiceRepository repo, ServiceDbContext serviceDbContext)
        {
            repository = repo;
            context = serviceDbContext;

        }
        
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string email, string name, string surname, DateTime date)
        {
            
            int count=repository.Users.Where(b => b.Email == email).Count();
            if (count == 0)
            {
                context.Users.Add(new User { Name = name, Surname = surname, BirthDate = date, Email = email });
                context.SaveChanges();
                ViewBag.email = "true";
                return View();
            }
            else
            {
                ViewBag.email = "false";
                return View();
            }

        }
        public ViewResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string email)
        {
            int count = repository.Users.Where(b => b.Email == email).Count();
            if (count == 1)
            {
                ViewBag.email = "true";
                return View();
            }
            else
            {
                ViewBag.email = "false";
                return View();
            }
        }
    }
}
