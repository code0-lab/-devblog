using Blog.Data.Context;
using Blog.Data.Extensions;
using Microsoft.EntityFrameworkCore; // EntityFrameworkCore.SqlServer paketini y�kledik.//

var builder = WebApplication.CreateBuilder(args); // WebApplication.CreateBuilder(args) ile bir builder olu�turduk.//

builder.Services.LoadDataLayerExtension(builder.Configuration);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Proje ba�lamadan �nce yukardaki servis listesini build etmek i�in kullan�l�r.(her bir servis d�zg�n �al��mal�)//

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

app.MapRazorPages();

app.Run();
