using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// Add service
builder.Services.AddDbContext<HoaLanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HoaLan")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
// Add secction
builder.Services.AddDistributedMemoryCache(); // Có thể thay thế bằng cơ chế lưu trữ cache khác nếu cần
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian tự động hủy session sau 30 phút không sử dụng
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
