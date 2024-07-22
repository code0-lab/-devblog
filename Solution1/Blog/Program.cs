using Blog.Data.Context;
using Blog.Data.Extensions;
using Microsoft.EntityFrameworkCore; // EntityFrameworkCore.SqlServer paketini yükledik.//

var builder = WebApplication.CreateBuilder(args); // WebApplication.CreateBuilder(args) ile bir builder oluþturduk.//

builder.Services.LoadDataLayerExtension(builder.Configuration);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build(); // Proje baþlamadan önce yukardaki servis listesini build etmek için kullanýlýr.(her bir servis düzgün çalýþmalý)//

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
