using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_Extensions;
using Mag2_Models;
using Mag2_Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    [Authorize(Roles = WebConst.AdminRole)]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

            inquiryVM.inquiryDetails = this.inqDetailRepos.GetAll(x=>x.InquiryHeaderId==inquiryVM.InquiryHeader.Id);

            foreach (var item in inquiryVM.inquiryDetails)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    ProductId=item.ProductId
                };
                shoppingCartList.Add(shoppingCart);
            }
            HttpContext.Session.Clear();
            HttpContext.Session.Set(WebConst.SessionCart,shoppingCartList);
            HttpContext.Session.Set(WebConst.SessionInquiryId, inquiryVM.InquiryHeader.Id);
            TempData[WebConst.Success] = "Inquiry details successfull";
            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            InquiryHeader inquiryHeader= this.inqHeaderRepos.FirstOrDefault(x => x.Id== inquiryVM.InquiryHeader.Id);
            IEnumerable<InquiryDetail> inquiryDetails= this.inqDetailRepos.GetAll(x => x.InquiryHeaderId == inquiryVM.InquiryHeader.Id);
            this.inqDetailRepos.RemoveRange(inquiryDetails);
            this.inqHeaderRepos.Remove(inquiryHeader);
            this.inqHeaderRepos.Save();

            TempData[WebConst.Success] = "Inquiry delete successfull";
            return RedirectToAction(nameof(Index));
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
