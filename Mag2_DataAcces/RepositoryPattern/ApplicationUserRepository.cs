using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_DataAcces.RepositoryPattern
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext db;
        public ApplicationUserRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }
    }
}
