using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ccse_cw1.Models;
using ccse_cw1.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// add repositories to services
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<BookingRepository>();
//builder.Services.AddTransient<HotelRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddControllers().AddJsonOptions(options =>
{ // ignore cycles of data when returning data (useful for reducing navigator load)
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
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

app.UseAuthorization();

// map pages and api controllers
app.MapControllers();
app.MapRazorPages();

app.Run();
