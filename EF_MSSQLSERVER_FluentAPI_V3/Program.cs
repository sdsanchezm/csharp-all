using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ef_api5;
using ef_api5.Models;

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

app.MapGet("/tareas", async ([FromServices] TareasContext DbContext) => 
{
    return Results.Ok(DbContext.Tareas);
});

app.MapGet("/tareasprioridad", async ([FromServices] TareasContext DbContext) => 
{
    return Results.Ok(DbContext.Tareas.Where(p => p.PrioridadTarea == ef_api5.Models.Prioridad.Alta));
});

app.MapGet("/tareasalta", async ([FromServices] TareasContext DbContext) => 
{
    return Results.Ok(DbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == ef_api5.Models.Prioridad.Alta));
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => 
{
		var tareas = await dbContext.Tareas.Include(p => p.Categoria).ToListAsync();
		return Results.Ok(tareas);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea ) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;

    await dbContext.AddAsync(tarea);
    // dbContext.Tarea.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

// this is the POST structure: 
// {
//     "categoriaId": "5735e94e-8d36-4e9c-882c-295a16597947",
//     "titulo": "task-new-4",
//     "tareaNotes3": "zxc3",
//     "tareaCat": "this is a new Katze task",
//     "descripcion": null,
//     "prioridadTarea": 2
// }


app.Run();

