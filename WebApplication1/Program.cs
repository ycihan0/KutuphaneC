using Kutuphane.Data;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // tam bu noktaya programýmýzýn bir db dontext kullanacaðýný belirtmemiz gerekiyor.
            //install-package Microsoft.EntityframeworkCore.SqlServer
            //yukarýdaki paket yüklenmesi gerekiyor.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //Diðer kurulmasý gereken paketler;
            //install-package Microsoft.EntityFrameworkCore.Tools
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}