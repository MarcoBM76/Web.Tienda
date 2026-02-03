using BussinessLogic.Features.Articulos;
using BussinessLogic.Features.ArticuloTienda;
using BussinessLogic.Features.ClienteArticulos;
using BussinessLogic.Features.Clientes;
using BussinessLogic.Features.Tienda;
using BussinessLogic.Interfaces;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services BL
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITiendaService, TiendaService>();
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IClienteArticuloService, ClienteArticuloService>();
builder.Services.AddScoped<IArticuloTiendaService, ArticuloTiendaService>();


// Add Services DA
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITiendaRepository, TiendaRepository>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IClienteArticuloRepository, ClienteArticuloRepository>();
builder.Services.AddScoped<IArticuloTiendaRepository, ArticuloTiendarepository>();

// Add DbContext
builder.Services.AddDbContext<TiendaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbTienda"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x =>
x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//Scaffold - Dbcontext Name = DbTienda Microsoft.EntityFrameworkCore.SqlServer - startupProject Api.Tienda - project DataAccess - outputDir.. / Entities - contextDir Context - context TiendaDbContext - force