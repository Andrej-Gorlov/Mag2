using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_DataAcces.RepositoryPattern
{
    public class ApplicationTypeRepository : Repository<ApplicationType>, IApplicationTypeRepository
    {
        private readonly ApplicationDbContext db;
        public ApplicationTypeRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }
        public void Update(ApplicationType obj)
        {
            var objFromDb = base.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name = obj.Name;
            }
        }
    }
}
