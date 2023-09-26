using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MtecDevs.Data;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


// Serviçoes próprios para o projeto funcionar
string conn = builder.Configuration.GetConnectionString("MtecDevs");
var version = ServerVersion.AutoDetect(conn); // detectar a versão do banco de dados


// Adicionar o serviço de conexão com o banco de dados - Entity
builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseMySql(conn, version)
); // Precisa saber as opções


// Serviço de gestão de Usuários - Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()  // classe da conta
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
;


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