using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Tracking_Tool_MVC.Data;
using Project_Tracking_Tool_MVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProjectTrackingToolDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectTrackingToolConnectionString")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ProjectTrackingToolDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProjectTrackingToolDbContext>();
builder.Services.AddScoped<IProjectRepository, ProjectReposirtory>();


builder.Services.AddScoped<IJobRepository, JobReposirtory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
