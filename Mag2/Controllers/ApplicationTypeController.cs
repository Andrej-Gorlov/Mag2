
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
            this.appTapeRepos = appTapeRepos;// доступ к бд для получения данных
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

        //Добовление в БД
        [HttpPost]//явное определения экшин метота типа post
        [ValidateAntiForgeryToken]//защита от взлома
        public IActionResult Creat(ApplicationType obj)
        {
            this.appTapeRepos.Add(obj);
            this.appTapeRepos.Save();//передача?(проверка) и сохранения изминений
            TempData[WebConst.Success] = "Application type creat successfull";
            return RedirectToAction("Index");
        }






        //get-edit___________________________________________________________________________________
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var o = this.appTapeRepos.Find(id.GetValueOrDefault());// Find работает с атребутами первичного ключа

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
                this.appTapeRepos.Update(obj);
                this.appTapeRepos.Save();
                TempData[WebConst.Success] = "Application type edit successfull";
                return RedirectToAction("Index");
            }
            TempData[WebConst.Error] = "Error while edit application type";
            return View(obj);
        }

        //get-delete___________________________________________________________________________________
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
        //Удаление в БД
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
