using Mag2_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Data
{
    //при ApplicationDbContext: DbContext устонавливае пакет .EntityFrameworkCore.sqlserver
    public class ApplicationDbContext: IdentityDbContext //устонавливае пакет .AspNetCore.Identity.EntityFrameworkCore (login)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//использования функционала DbContext
        {
        }
        public DbSet<Category> Category { get; set; }//создание таблицы в бд с именим Сategery
        public DbSet<ApplicationType> ApplicationType { get; set; }//создание таблицы в бд с именим ApplicationType
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
