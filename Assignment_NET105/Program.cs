
using Assignment_NET105.Core.Domain.Models;
using Assignment_NET105.Infrastructure.DatabaseContext;
using Assignment_NET105.Repositories;
using Assignment_NET105.RepositoryContracts;
using Assignment_NET105.ServiceContracts;
using Assignment_NET105.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment_NET105.Core.ServiceContracts;
using Assignment_NET105.Core.RepositoryContracts;
using Assignment_NET105.Infrastructure.Repositories;
using Assignment_NET105.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IChatLieuRepository, ChatLieuRepository>();
builder.Services.AddScoped<IChatLieuAddService, ChatLieuAddService>();
builder.Services.AddScoped<IChatLieuGetService, ChatLieuGetService>();
builder.Services.AddScoped<IChatLieuSortService, ChatLieuSortService>();
builder.Services.AddScoped<IChatLieuUpdateService, ChatLieuUpdateService>();

builder.Services.AddScoped<IChuongTrinhKhuyenMaiRepository, ChuongTrinhKhuyenMaiRepository>();
builder.Services.AddScoped<IChuongTrinhKhuyenMaiAddService, ChuongTrinhKhuyenMaiAddService>();
builder.Services.AddScoped<IChuongTrinhKhuyenMaiGetService, ChuongTrinhKhuyenMaiGetService>();
builder.Services.AddScoped<IChuongTrinhKhuyenMaiSortService, ChuongTrinhKhuyenMaiSortService>();
builder.Services.AddScoped<IChuongTrinhKhuyenMaiUpdateService, ChuongTrinhKhuyenMaiUpdateService>();

builder.Services.AddScoped<IMauSacRepository, MauSacRepository>();
builder.Services.AddScoped<IMauSacAddService, MauSacAddService>();
builder.Services.AddScoped<IMauSacGetService, MauSacGetService>();
builder.Services.AddScoped<IMauSacSortService, MauSacSortService>();
builder.Services.AddScoped<IMauSacUpdateService, MauSacUpdateService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredUniqueChars = 3;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()

    .AddDefaultTokenProviders()

    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()

    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();



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
