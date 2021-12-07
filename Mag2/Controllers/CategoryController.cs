using Mag2.Data;
using Mag2.Models;
using Mag2_Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    [Authorize(Roles = WebConst.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;// доступ к бд для получения данных
        }



        public IActionResult Index()
        {
            IEnumerable<Category> objList = db.Category;// записываем данные из таблицы Categery в объект "objList"

            return View(objList);
        }


        //get-creat___________________________________________________________________________________
        public IActionResult Creat()
        {
            return View();
        }

        //Добовление в БД
        [HttpPost]//явное определения экшин метота типа post
        [ValidateAntiForgeryToken]//защита от взлома
        public IActionResult Creat(Category obj)
        {
            // выполненены все ли правела для модели (т.е валидные)
            if (ModelState.IsValid)
            {
                this.db.Category.Add(obj);
                this.db.SaveChanges();//передача?(проверка) и сохранения изминений
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //get-edit___________________________________________________________________________________
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var o = this.db.Category.Find(id);// Find работает с атребутами первичного ключа

            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        //Добовление изминения в БД
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                this.db.Category.Update(obj);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
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
