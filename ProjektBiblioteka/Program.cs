using Microsoft.EntityFrameworkCore;
using ProjektBiblioteka.Context;
using ProjektBiblioteka.Services.Books;
using ProjektBiblioteka.Services.Borrow;
using ProjektBiblioteka.Services.People;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("LibraryDbContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
