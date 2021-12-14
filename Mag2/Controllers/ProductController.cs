using Mag2_DataAcces;
using Mag2_Models;
using Mag2_Models.ViewModels;
using Mag2_Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mag2_DataAcces.RepositoryPattern.IRepository;

namespace Mag2.Controllers
{
    [Authorize(Roles = WebConst.AdminRole)]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepos;
        private readonly IWebHostEnvironment _webHostEnvironment;//(используем паттерн зависимости)
        public ProductController(IProductRepository productRepos, IWebHostEnvironment IWHE)
        {
            this.productRepos = productRepos;
            _webHostEnvironment = IWHE;//доступ к корневой папки (для img)
        }



        public IActionResult Index()
        {
            // Обращаемся к бд единыжды(получение Name)
            IEnumerable<Product> objList = this.productRepos.GetAll(includeProperties:"Category,ApplicationType");


            //Множественное обращение к бд
            //IEnumerable<Product> objList = db.Product;

            //foreach (var item in objList)// инфа о Categery
            //{
            //    item.Category = this.db.Category.FirstOrDefault(x => x.Id == item.CategoryId);
            //    item.ApplicationType = this.db.ApplicationType.FirstOrDefault(x => x.Id == item.ApplicationTypeId);
            //}

            return View(objList);
        }





        //get-(creat and edit)___________________________________________________________________________________
        public IActionResult Upsert(int? id)
        {
            //-----(строгой типизации нет при использовании ViewBag и ViewData)-------
            // нужно для раскрывающийся список категорий
            //IEnumerable<SelectListItem> CategoryDropDown=_db.Сategery.Select(x=>new SelectListItem 
            //{ 
            //    Text=x.Name,
            //    Value=x.Id.ToString()
            //});  //получаем все категории из бд
            // ViewBag.CDD = CategoryDropDown;//передача данных в представление (View((вывод на экран)) (нужен когда временные данные не содержится в модели)  (в представление ( asp-items="@ViewBag.CDD" ) 
            // ViewData["CDD"] = CategoryDropDown;  |||[dictionary] ключ-"CDD", value-CategoryDropDown (в представление (asp-items="@ViewData["CDD"] as IEnumerable<SelectListItem>" ) )(~ в чём разница с ViewBag??? ~)
            //Product product = new Product();

            //------ сохраняется строгоя типизации (из-за добовления в Model объекта(например ProductVM))-------
            // отображение в выпадающем списке
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = this.productRepos.GetAllDropdownList(WebConst.CategoryName),
                ApplicationTypeSelectList = this.productRepos.GetAllDropdownList(WebConst.ApplicationTypeName)
            };

            if (id == null)//creat
            {

                return View(productVM);
            }
            else
            {
                productVM.Product = this.productRepos.Find(id.GetValueOrDefault());//извличения товара из бд по id
                if (productVM.Product == null)
                {
                    return NotFound();
                }
                return View(productVM);
            }
        }


        //Добовление в БД
        [HttpPost]//явное определения экшин метота типа post
        [ValidateAntiForgeryToken]//защита от взлома
        public IActionResult Upsert(ProductVM proMV)
        {
            // выполненены все ли правела для модели (т.е валидные)
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;//извлекаем img
                string webRootPath = _webHostEnvironment.WebRootPath;//путь к папке wwwroot

                if (proMV.Product.Id == 0)
                {
                    //Creatig new сущности
                    string upload = webRootPath + WebConst.ImagePath;//путь к img 
                    string feilName = Guid.NewGuid().ToString();//случайное new имя 
                    string extension = Path.GetExtension(files[0].FileName);//расширение файла

                    //copy feils в new место которое опредиляется значением (upload)
                    using (var fileStream = new FileStream(Path.Combine(upload, feilName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    // обновляется сылка на img
                    proMV.Product.Image = feilName + extension;
                    this.productRepos.Add(proMV.Product);//добовляем new img 
                }
                else//updating (обновляем)
                {
                    var oFromDb = this.productRepos.FirstOrDefault(x => x.Id == proMV.Product.Id,isTracking:false);//существующие названия file  (-- AsNoTracking() отключает отслеживания сущности (нужно для обновления db(иначе будет конфликт с (_db.Products.Update(proMV.Product)))) --)

                    if (files.Count > 0)//т.е file уже получен для существующего продукта
                    {
                        string upload = webRootPath + WebConst.ImagePath;
                        string feilName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        var oldFile = Path.Combine(upload, oFromDb.Image);//ссылка на существующие img

                        if (System.IO.File.Exists(oldFile))//если filt существует
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        using (var fileStream = new FileStream(Path.Combine(upload, feilName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        proMV.Product.Image = feilName + extension;
                    }
                    else//т.е img не менялось!!!
                    {
                        proMV.Product.Image = oFromDb.Image;//img остаётся прежним.
                    }

                    this.productRepos.Update(proMV.Product);
                }
                this.productRepos.Save();//передача?(проверка) и сохранения изминений
                TempData[WebConst.Success] = "Product type update successfull";

                return RedirectToAction("Index");
            }

            proMV.CategorySelectList = this.productRepos.GetAllDropdownList(WebConst.CategoryName);
            proMV.ApplicationTypeSelectList = this.productRepos.GetAllDropdownList(WebConst.ApplicationTypeName);
            TempData[WebConst.Error] = "Error while update product type";
            return View(proMV);
        }






        //get-delete___________________________________________________________________________________
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Product product = this.db.Product.Include(x => x.Category).Include(x => x.ApplicationType).FirstOrDefault(x => x.Id == id);//жадная загрузка Include()
            //product.Categery= _db.Сategery.Find(product.CategeryId); //получаем каткгорию товара
            Product product = this.productRepos.FirstOrDefault(x=>x.Id==id,includeProperties: "Category,ApplicationType");
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //Удаление в БД
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var o = this.productRepos.Find(id.GetValueOrDefault());

            if (o == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + WebConst.ImagePath;//путь к img
            var oldFile = Path.Combine(upload, o.Image);//ссылка на существующие img

            if (System.IO.File.Exists(oldFile))//если filt существует
            {
                System.IO.File.Delete(oldFile);
            }
            this.productRepos.Remove(o);
            this.productRepos.Save();
            TempData[WebConst.Success] = "Product type delete successfull";
            return RedirectToAction("Index");
        }
    }
}
