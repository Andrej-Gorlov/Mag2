using Mag2.Data;
using Mag2.Models;
using Mag2.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment _webHostEnvironment;//(используем паттерн зависимости)
        public ProductController(ApplicationDbContext db)
        {
            this.db = db;// доступ к бд для получения данных
        }



        public IActionResult Index()
        {
            IEnumerable<Product> objList = db.Product;

            foreach (var item in objList)// инфа о Categery
            {
                item.Category = this.db.Category.FirstOrDefault(x => x.Id == item.CategoryId);
            }

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
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = this.db.Category.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if (id == null)//creat
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = this.db.Product.Find(id);//извличения товара из бд по id
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
                    this.db.Product.Add(proMV.Product);//добовляем new img товара
                }
                else//updating (обновляем)
                {
                    var oFromDb = this.db.Product.AsNoTracking().FirstOrDefault(x => x.Id == proMV.Product.Id);//существующие названия file  (-- AsNoTracking() отключает отслеживания сущности (нужно для обновления db(иначе будет конфликт с (_db.Products.Update(proMV.Product)))) --)

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

                    this.db.Product.Update(proMV.Product);
                }
                this.db.SaveChanges();//передача?(проверка) и сохранения изминений
                return RedirectToAction("Index");
            }

            proMV.CategorySelectList = this.db.Category.Select(x => new SelectListItem //НУЖНО ДЛЯ РАБОТЫ ВЫПАДАЮЩЕГО СПИСКА В СЛУЧАЕ НЕПРАВИЛЬНОГО ЗАПОЛНЕНИЯ (т.е не волиден) !!!
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(proMV);
        }






        //get-delete___________________________________________________________________________________
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var o = this.db.Category.Find(id);

            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        //Удаление в БД
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var o = this.db.Category.Find(id);

            if (o == null)
            {
                return NotFound();
            }
            this.db.Category.Remove(o);
            this.db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
