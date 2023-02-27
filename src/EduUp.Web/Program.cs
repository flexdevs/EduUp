using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.Accounts;
using EduUp.Service.Interfaces.Authors;
using EduUp.Service.Interfaces.Categories;
using EduUp.Service.Interfaces.Courses;
using EduUp.Service.Interfaces.IntroVideos;
using EduUp.Service.Interfaces.Verify;
using EduUp.Service.Interfaces.Videos;
using EduUp.Service.Security;
using EduUp.Service.Services;
using EduUp.Service.Services.Accounts;
using EduUp.Service.Services.Authors;
using EduUp.Service.Services.Categories;
using EduUp.Service.Services.Courses;
using EduUp.Service.Services.IntroVideos;
using EduUp.Service.Services.Verify;
using EduUp.Service.Services.Videos;
using EduUp.Web.Configurations;
using EduUp.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddWeb(builder.Configuration);


string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IVerifyEmailService, VerifyEmailService>();
builder.Services.AddScoped<IAuthorsService, AuthorsService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IIntroVideoService, IntroVideoService>();
builder.Services.AddScoped<IVideoService, VideoService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.HttpContext.Response.Redirect("accounts/login");
    }
});
app.UseMiddleware<TokenRedirectMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "admins/{controller=courses}/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
