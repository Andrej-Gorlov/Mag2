using Mag2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag2.Data
{
    public class ApplicationDbContext: DbContext //устонавливае пакет .EntityFrameworkCore.sqlserver
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//использования функционала DbContext
        {
        }
        public DbSet<Category> Category { get; set; }//создание таблицы в бд с именим Сategery
        public DbSet<ApplicationType> ApplicationType { get; set; }//создание таблицы в бд с именим ApplicationType
    }
}
