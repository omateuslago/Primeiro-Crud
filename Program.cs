using cruudd.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext: Adiciona o AppDbContext na injeção de dependência do ASP.NET Core.
//<AppDbContext>: Diz que o projeto vai usar o AppDbContext para acessar o banco de dados.
//options => {}: Define o que vai nas opções de configuração do banco. A variável options está representando
//o DbContextOptions<AppDbContext>.
//options.UseSqlServer: Diz ao EF para usar o SQL Server como banco de dados.
//(builder.Configuration.GetConnectionString("DefaultConnection")): Busca a string de conexão chamada
//"DefaultConnection" no appsettings.json.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cadastro}/{action=Index}/{id?}");

app.Run();
