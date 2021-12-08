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
    public class InquiryDetailRepository : Repository<InquiryDetail>, IInquiryDetailRepository
    {
        private readonly ApplicationDbContext db;
        public InquiryDetailRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }


        public void Update(InquiryDetail obj)
        {
            this.db.InquiryDetail.Update(obj);//update all
        }
    }
}
