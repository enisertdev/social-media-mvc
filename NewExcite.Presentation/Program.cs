using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using NewExcite.Business.Services;
using NewExcite.Business.Services.Abstract;
using NewExcite.Business.ValidationRules.AppUserValidationRules;
using NewExcite.DataAccess.Abstract;
using NewExcite.DataAccess.Concrete.Data;
using NewExcite.DataAccess.Repositories;
using NewExcite.Entitiy.Concrete;
using NewExcite.Presentation.Models;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<AppUserRegisterValidator>();
});

builder.Services.AddDbContext<NewExciteDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<NewExciteDbContext>().AddErrorDescriber<UserIdentityValidator>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;

});
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["GoogleSecrets:clientId"];
    googleOptions.ClientSecret = configuration["GoogleSecrets:clientSecret"];
    googleOptions.CallbackPath = configuration["GoogleSecrets:callBackPath"];
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Logout/Logout";
});
builder.Services.AddSingleton<EmailService>();
builder.Services.AddScoped<IUserPostService, UserPostService>();
builder.Services.AddScoped<IUserPostRepository, UserPostRepository>();
builder.Services.AddScoped<IUserCommentRepository, UserCommentRepository>();
builder.Services.AddScoped<IUserCommentService, UserCommentService>();
builder.Services.AddScoped<IUserLikeService, UserLikeService>();
builder.Services.AddScoped<IUserLikeRepository, UserLikeRepository>();
builder.Services.AddScoped<IFriendshipRepository, FriendshipRepository>();
builder.Services.AddScoped<IFriendshipService, FriendshipService>();



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
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
