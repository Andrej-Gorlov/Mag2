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
            IEnumerable<Category> objList = catRepos.GetAll();

            return View(objList);
        }



        public IActionResult Creat()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(Category obj)
        {
            if (ModelState.IsValid)
            {
                this.catRepos.Add(obj);
                this.catRepos.Save();
                TempData[WebConst.Success] = "Category created successfull";
                return RedirectToAction("Index");
            }
            TempData[WebConst.Error] = "Error while creating category";
            return View(obj);
        }


        public IActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                this.catRepos.Update(obj);
                this.catRepos.Save();
                TempData[WebConst.Success] = "Category edit successfull";
                return RedirectToAction("Index");
            }
            TempData[WebConst.Error] = "Error while edit category";
            return View(obj);
        }




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
            TempData[WebConst.Success] = "Category delete successfull";
            return RedirectToAction("Index");
        }
    }
}
