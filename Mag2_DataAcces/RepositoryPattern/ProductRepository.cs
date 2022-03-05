using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Extensions;
using Mag2_Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_DataAcces.RepositoryPattern
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }

        public IEnumerable<SelectListItem> GetAllDropdownList(string obj)
        {
            if (obj==WebConst.CategoryName)
            {
                return this.db.Category.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            }
            if (obj==WebConst.ApplicationTypeName)
            {
                return this.db.ApplicationType.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
            }
            return null;
        }

        public void Update(Product obj)
        {
            this.db.Product.Update(obj);
        }
    }
}
