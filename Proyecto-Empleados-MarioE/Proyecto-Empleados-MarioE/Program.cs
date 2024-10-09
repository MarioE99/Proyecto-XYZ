using Microsoft.EntityFrameworkCore;
using Proyecto_Empleados_MarioE;
using Proyecto_Empleados_MarioE.Models;


var builder = WebApplication.CreateBuilder(args);

RSAEncrypt.GenerateKeys("publicKey.xml", "privateKey.xml");
string encryptedPassword = RSAEncrypt.Encrypt("mario1999", "publicKey.xml");
string decryptedPassword = RSAEncrypt.Decrypt(encryptedPassword, "privateKey.xml");



string connectionString = $"Server=35.232.115.112;Database=DBCRUDMVC;User=SQLV1;Password={decryptedPassword};TrustServerCertificate=True;";


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbxyzContext>(options =>
        options.UseSqlServer(connectionString));

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

app.Run();
