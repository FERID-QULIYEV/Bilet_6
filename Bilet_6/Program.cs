using Bilet_6.DAL;
using Microsoft.EntityFrameworkCore;

namespace Bilet_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
            });
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(name: "areas",pattern: "{area:exists}/{controller=Team}/{action=Index}/{id?}");
            app.MapControllerRoute("default","{controller=home}/{action=index}/{id?}");
            app.MapControllerRoute("default", "{controller=Account}/{action=Login}/{id?}");
            app.Run();
        }
    }
}