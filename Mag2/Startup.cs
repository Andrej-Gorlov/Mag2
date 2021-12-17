using Mag2_Extensions;
using Mag2_DataAcces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mag2_DataAcces.RepositoryPattern.IRepository;
using Mag2_DataAcces.RepositoryPattern;
using Mag2_Extensions.BrainTree;

namespace Mag2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(
                Configuration.GetConnectionString("DefConnection")));//подключение sqlserver

            services.AddIdentity<IdentityUser, IdentityRole>()//подключенияе IdentityDbContext, устонавливаем пакет .AspNetCore.Identity.UI
                .AddDefaultTokenProviders()//предостовление токинов по умолчанию (позволяет получить токен при потери пароля)
                .AddDefaultUI()//
                .AddEntityFrameworkStores<ApplicationDbContext>();//AddEntityFrameworkStores при migration creat table в db 


            //регистрация email services
            services.AddTransient<IEmailSender, EmailSender>();// при каждом запросе на email services будет cerat new объект и предоставлен для запроса 
            services.AddSingleton<IBrainTreeGate, BrainTreeGet>();

            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();// добовляем сервисы (для добовления товара в корзину)
            services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(10);// через 10 мин будет обнуление (например товара в корзине)
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
            });

            services.Configure<BrainTreeSettings>(Configuration.GetSection("BrainTree"));

            services.AddScoped<ICategoryRepository, CategoryRepository>();//регистрация ICategoryRepository
            services.AddScoped<IApplicationTypeRepository, ApplicationTypeRepository>();// IApplicationTypeRepository
            services.AddScoped<IProductRepository, ProductRepository>();// IProductRepository
            services.AddScoped<IInquiryHeaderRepository, InquiryHeaderRepository>();
            services.AddScoped<IInquiryDetailRepository, InquiryDetailRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            services.AddScoped<IOrderHeaderRepository, OrderHeaderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();//добовление authentication в контейнер

            app.UseAuthorization();

            app.UseSession();//добавляем сессию в контейнер (services.AddSession(x =>x...))

            app.UseEndpoints(endpoints =>
            {
                // маршрутизация для Razor
                endpoints.MapRazorPages();
                // маршрутизация для MVC
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
