using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Models.ViewModels;
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

        [BindProperty]//доступны все данные для post
        public InquiryVM inquiryVM { get; set; }

        public InquiryController(IInquiryHeaderRepository inqHeaderRepos, IInquiryDetailRepository inqDetailRepos)
        {
            this.inqHeaderRepos = inqHeaderRepos;
            this.inqDetailRepos = inqDetailRepos;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            inquiryVM = new InquiryVM()
            {
                 InquiryHeader=this.inqHeaderRepos.FirstOrDefault(x=>x.Id==id),
                 inquiryDetails=this.inqDetailRepos.GetAll(x=>x.InquiryHeaderId==id,includeProperties: "Product")
            };
            return View(inquiryVM);
        }

        #region
        [HttpGet]
        public IActionResult GetInquiryList() 
        {
            return Json(new { data = this.inqHeaderRepos.GetAll() });
        }
        #endregion
    }
}
