using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// layanan session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Waktu session aktif
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware session
app.UseSession();

app.UseAuthorization();

app.UseMiddleware<AuthorizationMiddleware>();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    /*pattern: "{controller=Home}/{action=Index}/{id?}");*/
    pattern: "{controller=Login}/{action=Account}/{id?}");

app.Run();
