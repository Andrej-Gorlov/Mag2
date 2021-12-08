using Mag2_DataAcces;
using Mag2_Models;
using Mag2_Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mag2_DataAcces.RepositoryPattern.IRepository;

namespace Mag2.Controllers
{
    [Authorize(Roles = WebConst.AdminRole)]
    public class CategoryController : Controller
    {


        private readonly ICategoryRepository catRepos;
        public CategoryController(ICategoryRepository catRepos)
        {
            this.catRepos = catRepos;
        }



        public IActionResult Index()
        {
            IEnumerable<Category> objList = catRepos.GetAll();// записываем данные из таблицы Categery в объект "objList"

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
                this.catRepos.Add(obj);
                this.catRepos.Save();
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

            var o = this.catRepos.Find(id.GetValueOrDefault());// Find работает с атребутами первичного ключа

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
                this.catRepos.Update(obj);
                this.catRepos.Save();
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

            var o = this.catRepos.Find(id.GetValueOrDefault());

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
            var o = this.catRepos.Find(id.GetValueOrDefault());

            if (o == null)
            {
                return NotFound();
            }
            this.catRepos.Remove(o);
            this.catRepos.Save();
            return RedirectToAction("Index");
        }
    }
}
