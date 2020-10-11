using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Support_Your_Locals.Models.Repositories
{
    public class ServiceRepositoryDb : IServiceRepository
    {

        private ServiceDbContext context;

        public ServiceRepositoryDb(ServiceDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;
    }
}
