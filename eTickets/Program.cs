using eTickets.Data;
using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
//services Configuration
services.AddScoped<IActorsService, ActorsService>();
services.AddScoped<IProducersService, ProducersService>();
services.AddScoped<ICinemasService, CinemasService >();
services.AddScoped<IMoviesService, MoviesService>();  
services.AddScoped<IOrdersService,OrdersService>();

services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
//authentication
services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores < AppDbContext>() ;
services.AddMemoryCache();

services.AddSession();
services.AddAuthentication(options=>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

builder.Services.AddControllersWithViews();

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
app.UseSession();
app.UseAuthentication();    
app.UseAuthorization(); 


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();


app.Run();

