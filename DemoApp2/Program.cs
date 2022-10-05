using DemoApp2;
using DemoApp2.Data;
using DemoApp2.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
//1. สร้าง Project 
//2. Install nuget package npgsql , Depper
//3. กำหนดค่า ConnectionString ใน appsetting.json
//4. สร้าง Class static GbVer.cs สร้าง ตัวแปรเก็บ ConnectionString
//5. แก้ไข program.cs เพิ่มใส่ค่า connectionstring เข้าไปใน GbVar
//6. สร้าง Class Customer ไว้สำหรับเก็บข้อมูล ใน Folder Data
//7. สร้าง class ICustomerService , CustomerService ใน Folder Services
//8. สร้าง Function GetAllCustomer ใน CustomerService
//9. สร้าง Lazor page สำหรับ แสดงข้อมูล



ConfigurationManager config = builder.Configuration;
GbVer.ConnectionString = config["ConnectionStrings:ConStr1"];



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<ICustomerService, CustomerService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();