using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetMVC.Models;
using ProjetMVC.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));
builder.Services.AddIdentity<Utilisateur, IdentityRole>(options =>
{
    // Configurations de mot de passe
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
})
       .AddEntityFrameworkStores<MyDbContext>()
       .AddDefaultTokenProviders();

// Ajout des services d'application
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();


// Add services to the container.
builder.Services.AddScoped<IAdresseService, AdresseService>();
builder.Services.AddScoped<IBorneService, BorneService>();
builder.Services.AddHttpClient<GeocodingService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
