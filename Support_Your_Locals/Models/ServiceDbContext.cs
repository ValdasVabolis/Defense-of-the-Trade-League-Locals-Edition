using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Support_Your_Locals.Models {
    public class ServiceDbContext :DbContext{

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {

        }

        public DbSet<UserRegisterModel> Users { get; set; }
    }
}
