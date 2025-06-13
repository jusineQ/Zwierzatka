using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Zwierzatka.Models;
using Zwierzatka.Services;
using Zwierzatka.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IU¿ytkownikService, UzytkownikService>();
builder.Services.AddScoped<IZwierzetaService, ZwierzetaService>();
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ZwierzatkaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZwierzatkaDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
