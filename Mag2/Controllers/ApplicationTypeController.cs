using Mag2.Data;
using Mag2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext db;
        public ApplicationTypeController(ApplicationDbContext db)
        {
            this.db = db;// доступ к бд для получения данных
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = db.ApplicationType;
            return View(objList);
        }
        public IActionResult Creat()
        {
            return View();
        }

        //Добовление в БД
        [HttpPost]//явное определения экшин метота типа post
        [ValidateAntiForgeryToken]//защита от взлома
        public IActionResult Creat(ApplicationType obj)
        {
            this.db.ApplicationType.Add(obj);
            this.db.SaveChanges();//передача?(проверка) и сохранения изминений
            return RedirectToAction("Index");
        }






        //get-edit___________________________________________________________________________________
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var o = this.db.ApplicationType.Find(id);// Find работает с атребутами первичного ключа

            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }
        //Добовление изминения в БД
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                this.db.ApplicationType.Update(obj);
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

            var o = this.db.ApplicationType.Find(id);

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
            var o = this.db.ApplicationType.Find(id);

            if (o == null)
            {
                return NotFound();
            }
            this.db.ApplicationType .Remove(o);
            this.db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
