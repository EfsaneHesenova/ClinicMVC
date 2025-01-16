using Microsoft.EntityFrameworkCore;
using Project.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppdbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );


app.MapControllerRoute(
            name: "areas",
            pattern: "{controller=Home}/{action=Index}/{id?}"
          );

app.Run();
