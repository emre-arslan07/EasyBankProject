using EasyBankProject.BLL.Abstract;
using EasyBankProject.BLL.Concrete;
using EasyBankProject.DAL.Abstract;
using EasyBankProject.DAL.Concrete;
using EasyBankProject.DAL.EntityFramework;
using EasyBankProject.DAL.UnitOfWork;
using EasyBankProject.ENTITY.Concrete;
using EasyBankProject.UI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EasyBankProjectDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EasyBankProjectDbContext>().AddErrorDescriber<CustomerIdentityValidator>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICustomerAccountDal, EFCustomerAccountDal>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>();

builder.Services.AddScoped<ICustomerAccountProcessDal, EFCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

builder.Services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();

// Add services to the container.
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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
