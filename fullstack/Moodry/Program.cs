using Microsoft.AspNetCore.Authentication.Cookies;
using Moodry.Models.Manipulators;
using Moodry.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.Cookie.Name = "keksi";
    });


DatabaseManipulator.Initialize(builder.Configuration);
var app = builder.Build();


//Aktiviteetit
using (var scope = app.Services.CreateScope()) {
    var existing = DatabaseManipulator.GetAll<Activity>();

    if (!existing.Any()) {
        foreach (var a in DatabaseManipulator.GetDefaultActivities()) { DatabaseManipulator.SaveItem(a); }
    }
}


if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}").WithStaticAssets();

app.Run();