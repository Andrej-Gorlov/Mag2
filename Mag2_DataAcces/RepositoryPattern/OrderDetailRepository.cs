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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext db;
        public OrderDetailRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }


        public void Update(OrderDetail obj)
        {
            this.db.OrderDetail.Update(obj);//update all
        }
    }
}
