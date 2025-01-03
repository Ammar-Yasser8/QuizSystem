using Microsoft.EntityFrameworkCore;
using Quiz.DataAccess.Data;
using Quiz.DataAccess.Implementaions;
using Quiz.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using Quiz.Entities.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace QuizSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<QuizSysContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options =>
                 options.SignIn.RequireConfirmedAccount = false)
                 .AddEntityFrameworkStores<QuizSysContext>()
                 .AddDefaultTokenProviders()
                 .AddDefaultUI();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); ;
          


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{area=User}/{controller=Quiz}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "defualt",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                await SeedData.Initialize(services, userManager);
            }
            app.Run();
        }

    }
   
    

}
