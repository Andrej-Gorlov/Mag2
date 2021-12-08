using Mag2_DataAcces.RepositoryPattern.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    public class InquiryController : Controller
    {
        private readonly IInquiryHeaderRepository inqHeaderRepos;
        private readonly IInquiryDetailRepository inqDetailRepos;
        public InquiryController(IInquiryHeaderRepository inqHeaderRepos, IInquiryDetailRepository inqDetailRepos)
        {
            this.inqHeaderRepos = inqHeaderRepos;
            this.inqDetailRepos = inqDetailRepos;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
