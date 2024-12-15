using SkillFoundryAuthBasics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
    .AddCookie(Settings.AuthCookieName,
    options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/Forbidden";
        options.Cookie.Name = Settings.AuthCookieName;
    });

    builder.Services.AddAuthorization(
        options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireClaim("admin", "true"));
        });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
