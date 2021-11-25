using Mag2.AdditionalServices;
using Mag2.Data;
using Mag2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext db;
        public CartController(ApplicationDbContext db)
        {
            this.db = db;// доступ к бд для получения данных
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
            IEnumerable<Product> prodList = this.db.Product.Where(x => prodInCart.Contains(x.Id));

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

    }
}
