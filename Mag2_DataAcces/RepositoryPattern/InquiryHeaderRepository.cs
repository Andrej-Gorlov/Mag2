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
    public class InquiryHeaderRepository : Repository<InquiryHeader>, IInquiryHeaderRepository
    {
        private readonly ApplicationDbContext db;
        public InquiryHeaderRepository(ApplicationDbContext db):base (db)
        {
            this.db = db;
        }

        public void Update(InquiryHeader obj)
        {
            this.db.InquiryHeader.Update(obj);//update all
        }
    }
}
