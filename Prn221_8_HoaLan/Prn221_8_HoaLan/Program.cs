using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BussinessService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// Add service
builder.Services.AddDbContext<HoaLanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HoaLan")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IAuctionDetailRepository, AuctionDetailRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IAuctionService,  AuctionService>();
builder.Services.AddTransient<IUserService, UserService>();

// Add secction
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
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



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add middleware session into pipeline
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();


app.Run();
