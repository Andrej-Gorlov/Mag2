using Mag2_Extensions;
using Mag2_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mag2_DataAcces.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager <IdentityRole> roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void Initialize()
        {
            try
            {
                if (this.db.Database.GetPendingMigrations().Count()>0)//проверяем наличие незавершенных миграций в бд
                {
                    this.db.Database.Migrate();//выполняем все незавершенные миграции
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            // create roleAdmin
            if (!this.roleManager.RoleExistsAsync(WebConst.AdminRole).GetAwaiter().GetResult())//creat role admina при first регистрации
            {
                this.roleManager.CreateAsync(new IdentityRole(WebConst.AdminRole)).GetAwaiter().GetResult();
                this.roleManager.CreateAsync(new IdentityRole(WebConst.CustomerRole)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            this.userManager.CreateAsync(new ApplicationUser()//настройка first user
            {
                UserName = "qwe@www.com",
                Email = "qwe@www.com",
                EmailConfirmed = true,
                FullName ="Admin Tester",
                PhoneNumber= "1212121244"
            },"Qazxc123!").GetAwaiter().GetResult();

            ApplicationUser user = this.db.ApplicationUser.FirstOrDefault(x=>x.Email== "qwe@www.com");
            this.userManager.AddToRoleAsync(user, WebConst.AdminRole).GetAwaiter().GetResult();
        }
    }
}
