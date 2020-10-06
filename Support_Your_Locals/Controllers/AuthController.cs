﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Support_Your_Locals.Models;

namespace Support_Your_Locals.Controllers
{
    public class AuthController : Controller
    {

        private ServiceDbContext db;

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
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
                var allUsers = await db.Users.ToListAsync();
                return View("Thanks", allUsers);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> SignIn(UserLoginModel user) {
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
