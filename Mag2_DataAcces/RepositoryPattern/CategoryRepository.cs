using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_DataAcces.RepositoryPattern
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext db;
        public CategoryRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }
        public void Update(Category obj)
        {
            var objFromDb = this.db.Category.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.DisplayOrder = obj.DisplayOrder;
            }
        }
    }
}
