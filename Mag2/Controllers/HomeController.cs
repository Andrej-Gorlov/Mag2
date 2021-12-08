using Mag2_Extensions;
using Mag2_DataAcces;
using Mag2_Models;
using Mag2_Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mag2_DataAcces.RepositoryPattern.IRepository;

namespace Mag2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository productRepos;
        private readonly ICategoryRepository catRepos;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepos, ICategoryRepository catRepos)
        {
            this.productRepos = productRepos;
            this.catRepos = catRepos;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Products= this.productRepos.GetAll(includeProperties: "Category,ApplicationType"),
                Categories =this.catRepos.GetAll()
            };
            return View(homeVM);
        }


        public IActionResult Details(int id)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart) != null &&
                HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }


            DetailsVM DetailsVM = new DetailsVM()
            {
                Product = this.productRepos.FirstOrDefault(x=>x.Id==id,includeProperties: "Category,ApplicationType"),
                ExistsInCart = false
            };

            foreach (var item in shoppingCartList)
            {
                if (item.ProductId==id)
                {
                    DetailsVM.ExistsInCart = true;
                }
            }


            return View(DetailsVM);
        }


        //add товара в крзину___________________
        [HttpPost,ActionName("Details")]
        public IActionResult DetailsPost(int id)
        {
            //list корзины покупок
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart)!=null &&
                HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart).Count()>0)
            {
                // если есть товар може ещё добавить
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }
            shoppingCartList.Add(new ShoppingCart { ProductId = id });
            // установка сессии
            HttpContext.Session.Set(WebConst.SessionCart, shoppingCartList);

            return RedirectToAction(nameof(Index));//nameof выбирает только сущ., методы 
        }



        //delete из корзины_____________________
        public IActionResult RemoveFormCart(int id)
        {
            //list корзины покупок
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();

            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart) != null &&
                HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WebConst.SessionCart).Count() > 0)
            {
                // если есть товар може ещё добавить
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WebConst.SessionCart);
            }

            var itemToRemove = shoppingCartList.SingleOrDefault(x=>x.ProductId==id);//извличения товара по id
            if (itemToRemove!=null)
            {
                shoppingCartList.Remove(itemToRemove);
            }
            // установка сессии
            HttpContext.Session.Set(WebConst.SessionCart, shoppingCartList);

            return RedirectToAction(nameof(Index));//nameof выбирает только сущ., методы 
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
