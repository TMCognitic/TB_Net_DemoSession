using DemoSession.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache(); //<<-- Activer le service de gestion de mémoire
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "DemoSession.cookie"; //<--eviter les erreur de cookie si on développe plusieurs site en meme temps
    options.Cookie.HttpOnly = true;
    options.IdleTimeout = TimeSpan.FromSeconds(60);
}); //<<-- Activer les services de session

builder.Services.AddScoped<SessionManager>();


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
app.UseSession();
app.Run();
