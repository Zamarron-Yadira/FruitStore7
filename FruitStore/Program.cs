using FruitStore.Models.Entities;
using FruitStore.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);//agg desde el contexto para hacer el servicio:

//agg el repositorio como servicio:
builder.Services.AddTransient<Repository<Categorias>>();
builder.Services.AddTransient<ProductosRepository>();


builder.Services.AddDbContext<FruteriashopContext>( x=>
	 x.UseMySql("server=localhost;user=root;password=root;database=fruteriashop", 
	 Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")));

builder.Services.AddMvc();
var app = builder.Build();

app.UseFileServer();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );


app.MapDefaultControllerRoute();

app.Run();
