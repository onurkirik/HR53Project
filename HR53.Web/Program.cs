using HR53.Web.ClaimProviders;
using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using HR53.Repository.Data;
using HR53.Core.OptionsModel;
using HR53.Service.Services.Abstraction;
using HR53.Service.Services.Concrete;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"), options =>
{
    options.MigrationsAssembly("HR53.Repository");
})); 

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddIdentity<AppUser,  AppRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IClaimsTransformation, UserClaimProvider>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();
    cookieBuilder.Name = "AppUserCookieBuilder";
    opt.LoginPath = new PathString("/Home/SignIn");
    opt.LogoutPath = new PathString("/Home/LogOut");
    opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
});


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=SignIn}/{id?}");

app.Run();
