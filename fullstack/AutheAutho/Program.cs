using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/";
        options.LogoutPath = "/Home/Index";
        options.AccessDeniedPath = "/Home/AccessDenied";

        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.Cookie.Name = "keksi"; //Näkyy selaimen tiedoissa
    });
//Auth logiikka on parempi olla policyssa kuin controllerissa
builder.Services.AddAuthorization(options => {
    options.AddPolicy("NoAdminAccess", policy => {
        policy.RequireAssertion(context =>
            //KÄyttäjän pitää olla logged in ja käyttäjä ei saa olla admin
            (context.User.Identity.IsAuthenticated && !context.User.IsInRole("admin"))
        );
    });
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
