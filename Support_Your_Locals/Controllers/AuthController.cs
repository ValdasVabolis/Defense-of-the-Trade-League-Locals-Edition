using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support_Your_Locals.Infrastructure.Extensions;
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

        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string name, string surname, DateTime birthDate, string email, string passhash)
        {
            int count = repository.Users.Count(b => b.Email == email);
                if (count == 0)
                {
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(passhash, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);


                context.Users.Add(new User {Name = name, Surname = surname, BirthDate = birthDate, Email = email, Passhash = savedPasswordHash });
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

        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string passhash)
        {
            bool goodpass = false;
            User user = repository.Users.FirstOrDefault(b => b.Email == email);
            string savedPasswordHash = user.Passhash;
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(passhash, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    goodpass = true;
            if (user.Email == email && goodpass)
                {
                    ViewBag.email = "true";
                    HttpContext.Session.SetJson("user", user);
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
