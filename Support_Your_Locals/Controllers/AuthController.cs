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
        public void SignUp()
        {

        }
        public void SignIn()
        {

        }

    }
}
