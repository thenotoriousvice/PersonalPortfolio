using Microsoft.EntityFrameworkCore;
using PortfolioProject.Repository;
using PortfolioProject.Repository.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<PortfolioProject.Services.IBlogService, PortfolioProject.Services.BlogService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!db.BlogPosts.Any())
    {
        db.BlogPosts.Add(new BlogPost { Title = "How I built my Portfolio", Description = "Short note...", Content = "<p>Write the post in HTML...</p>" });
        db.BlogPosts.Add(new BlogPost { Title = "Understanding Dependency Injection", Description = "Short...", Content = "<p>...</p>" });
        db.SaveChanges();
    }
}

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
