using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Support_Your_Locals.Models;
using Support_Your_Locals.Models.Repositories;
using Support_Your_Locals.Models.ViewModels;

namespace Support_Your_Locals.Pages
{
    public class BusinessPageModel : PageModel
    {

        private IServiceRepository repository;

        public BusinessPageModel(IServiceRepository repo)
        {
            repository = repo;
        }

        public void OnGet(long businessId)
        {
            User user = repository.Users.FirstOrDefault(u => u.UserID == businessId);
            var query = from t in repository.TimeSheets where t.BusinessID == businessId);
            IEnumerable<TimeSheet> sheets = (IEnumerable<TimeSheet>)query;
        }

    }
}
