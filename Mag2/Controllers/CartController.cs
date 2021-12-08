using Mag2_Extensions;
using Mag2_DataAcces;
using Mag2_Models;
using Mag2_Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Mag2_DataAcces.RepositoryPattern.IRepository;

namespace Mag2.Controllers
{
    [Authorize]//доступ для авторизованых user(т.е если Authorize, то получаем доступ к корзине)
    public class CartController : Controller
    {
        private readonly IProductRepository productRepos;
        private readonly IApplicationUserRepository AppUserRepos;
        private readonly IInquiryHeaderRepository inqHeaderRepos;
        private readonly IInquiryDetailRepository inqDetailRepos;

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEmailSender emailSender;

        [BindProperty]//привязка для post запросов (т.е  можем не явно указывать в action metod в параметрах)
        public ProductUserVM ProductUserVM { get; set; }
        public CartController(IWebHostEnvironment webHostEnvironment, IEmailSender emailSender,
            IProductRepository productRepos, IApplicationUserRepository AppUserRepos,
            IInquiryHeaderRepository inqHeaderRepos, IInquiryDetailRepository inqDetailRepos)
        {
            this.productRepos = productRepos;
            this.AppUserRepos = AppUserRepos;
            this.inqHeaderRepos = inqHeaderRepos;
            this.inqDetailRepos = inqDetailRepos;

            this.webHostEnvironment = webHostEnvironment;// доступ к папке wwwroot
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart) != null &&
                HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);

            }
            //все товар из корзины 
            List<int> prodInCart = shoppingCartList.Select(x => x.ProductId).ToList(); 
            IEnumerable<Product> prodList = this.productRepos.GetAll(x => prodInCart.Contains(x.Id));

            return View(prodList);
        }

        public IActionResult Remove(int id)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart) != null &&
                HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);

            }

            shoppingCartList.Remove(shoppingCartList.FirstOrDefault(x => x.ProductId==id));

            HttpContext.Session.Set(WebConst.SessionCart, shoppingCartList);

            return RedirectToAction(nameof(Index));//nameof выбирает только сущ., методы 
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
           
            return RedirectToAction(nameof(Summary));
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity; //id user
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.Name);

            //доступ у корзине покупок
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart) != null &&
                HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);

            }
            //все товар из корзины 
            List<int> prodInCart = shoppingCartList.Select(x => x.ProductId).ToList();
            IEnumerable<Product> prodList = this.productRepos.GetAll(x => prodInCart.Contains(x.Id));


            ProductUserVM = new ProductUserVM()
            {
                ApplicationUser = this.AppUserRepos.FirstOrDefault(x => x.Id == claim.Value),// получение доступа к значению индификатора вошедшего в систему User (т.е id зарегистрированного user)(для получения всех сведений user)
                ProductsList =prodList.ToList() //отображаем все товары в корзине!!!
            };


            return View(ProductUserVM);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(ProductUserVM productUserVM)//productUserVM передаются все товары из корзины 
        {
            //find id user
            var claimsIndetity = (ClaimsIdentity)User.Identity;//даные текущего клиента
            var claim = claimsIndetity.FindFirst(ClaimTypes.NameIdentifier);// id user


            //доступ к шаблону Inquiry.html
            var PathToTemplate = this.webHostEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString()// косая черта(Path.DirectorySeparatorChar.ToString())
                + "templates" + Path.DirectorySeparatorChar.ToString()
                + "Inquiry.html";// путь к шаблону

            var subject = " New Inquiry ";
            string HtmlBody = "";

            using(StreamReader sr= System.IO.File.OpenText(PathToTemplate))
            {
                HtmlBody = sr.ReadToEnd();//
            }

            //Name: { 0}
            //Email: { 1}
            //Phone: { 2}
            //Products: { 3}

            StringBuilder productListSB = new StringBuilder();
            foreach (var item in productUserVM.ProductsList)
            {
                productListSB.Append($" - Name: {item.Name} <span style='font-size:14px;'> (ID: {item.Id})</span><br />");
            }

            string massegBody = string.Format(HtmlBody,
                productUserVM.ApplicationUser.FullName,
                productUserVM.ApplicationUser.Email,
                productUserVM.ApplicationUser.PhoneNumber,
                productListSB.ToString());

            await this.emailSender.SendEmailAsync(WebConst.EmailAdmin, subject, massegBody);

            //регистрация InquiryHeader и InquiryDetail в бд ________________________________
            InquiryHeader inquiryHeader = new InquiryHeader()
            {
                ApplicationUserId=claim.Value,
                FullName = productUserVM.ApplicationUser.FullName,
                Email = productUserVM.ApplicationUser.Email,
                PhoneNumber= productUserVM.ApplicationUser.PhoneNumber,
                InquiryDate=DateTime.Now
            };
            this.inqHeaderRepos.Add(inquiryHeader);
            this.inqHeaderRepos.Save();
            foreach (var item in productUserVM.ProductsList)
            {
                InquiryDetail inquiryDetail = new InquiryDetail()
                {
                    InquiryHeaderId= inquiryHeader.Id,
                    ProductId= item.Id
                };
                inqDetailRepos.Add(inquiryDetail);
            }
            inqDetailRepos.Save();
            //__________________________________________________________________



            return RedirectToAction(nameof(InquriyConfirmation));//nameof выбирает только сущ., методы 
        }
        public IActionResult InquriyConfirmation()//Подтверждение запроса
        {
            //clear данных текущий сессии
            HttpContext.Session.Clear();

            return View(ProductUserVM);
        }

    }
}
