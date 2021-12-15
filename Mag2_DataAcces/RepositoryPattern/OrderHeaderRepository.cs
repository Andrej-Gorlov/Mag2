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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext db;
        public OrderHeaderRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }

        public void Update(OrderHeader obj)
        {
            this.db.OrderHeader.Update(obj);//update all
        }
    }
}
