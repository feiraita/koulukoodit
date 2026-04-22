using Microsoft.AspNetCore.Authentication.Cookies;
using Phase7.Models.Manipulators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options => {
        options.ViewLocationFormats.Add("/Views/Pages/{0}.cshtml");
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/AccessDenied";

        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.Cookie.Name = "keksi"; //Näkyy selaimen tiedoissa
    });


//Initialize database with appsettings parameters
DatabaseManipulator.Initialize(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

//Ennen authorizaatiooo
app.UseAuthentication(); // Mahdollistaa sisäänkirjautumisen
app.UseAuthorization();  

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
