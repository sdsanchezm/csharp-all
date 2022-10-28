using ef_api5;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// this is for the database in memory
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("connTareasDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TareasContext DbContext) => 
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + DbContext.Database.IsInMemory() );
});

app.Run();

