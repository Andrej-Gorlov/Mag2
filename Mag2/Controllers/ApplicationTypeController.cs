
using Mag2_Models;
using Mag2_Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mag2_DataAcces;
using Mag2_DataAcces.RepositoryPattern.IRepository;

namespace Mag2.Controllers
{
    [Authorize(Roles = WebConst.AdminRole)]
    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationTypeRepository appTapeRepos;
        public ApplicationTypeController(IApplicationTypeRepository appTapeRepos)
        {
            this.appTapeRepos = appTapeRepos;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = appTapeRepos.GetAll();
            return View(objList);
        }
        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(ApplicationType obj)
        {
            this.appTapeRepos.Add(obj);
            this.appTapeRepos.Save();
            TempData[WebConst.Success] = "Application type creat successfull";
            return RedirectToAction("Index");
        }







        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var o = this.appTapeRepos.Find(id.GetValueOrDefault());// Find работает с атрибутами первичного ключа

            if (o == null)
            {
                return NotFound();
            }
            return View(o);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                this.appTapeRepos.Update(obj);
                this.appTapeRepos.Save();
                TempData[WebConst.Success] = "Application type edit successfull";
                return RedirectToAction("Index");
            }
            TempData[WebConst.Error] = "Error while edit application type";
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var o = this.appTapeRepos.Find(id.GetValueOrDefault());

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
            var o = this.appTapeRepos.Find(id.GetValueOrDefault());

            if (o == null)
            {
                return NotFound();
            }
            this.appTapeRepos.Remove(o);
            this.appTapeRepos.Save();
            TempData[WebConst.Success] = "Application type delete successfull";
            return RedirectToAction("Index");
        }
    }
}
