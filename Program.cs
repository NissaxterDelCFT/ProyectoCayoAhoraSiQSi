using Microsoft.EntityFrameworkCore;
using ProyectoCayoAhoraSiQSi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SistemaCftContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("conexionDb"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
