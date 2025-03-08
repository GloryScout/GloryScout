using GloryScout.ContextDB;
using GloryScout.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace GloryScout
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
            builder.Services.AddControllersWithViews();


			// to create the db from the code here
			builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
					builder.Configuration.GetConnectionString("MyConnection") // the connection string is in the appsettings.json
				));

			

			// Add Identity services.
			builder.Services.AddIdentity<User, IdentityRole<Guid>>()
	            .AddEntityFrameworkStores<AppDBContext>()
	            .AddDefaultTokenProviders()
	            .AddDefaultUI();

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
            
			app.UseAuthentication();  // Enable authentication middleware.
			app.UseAuthorization();

			app.MapControllers();
			app.MapRazorPages(); // Enables Identity UI Pages

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
