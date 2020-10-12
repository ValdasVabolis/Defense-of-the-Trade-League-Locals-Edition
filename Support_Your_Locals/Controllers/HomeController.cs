﻿using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Support_Your_Locals.Models.Repositories;
using Support_Your_Locals.Models.ViewModels;
using Support_Your_Locals.Models.ViewModels.BusinessBoard;

namespace Support_Your_Locals.Controllers
{
    public class HomeController : Controller
    {

        private IServiceRepository repository;
        public int PageSize = 4;

        public HomeController(IServiceRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int productPage = 1)
        {
            return View(new BusinessListViewModel
            {
                Businesses =
                    repository.Business.Where(b => category == null || b.Product == category)
                        .OrderBy(b => b.BusinessID).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? repository.Business.Count()
                        : repository.Business.Where(b => b.Product == category).Count()
                },
                CurrentCategory = category
            });
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
