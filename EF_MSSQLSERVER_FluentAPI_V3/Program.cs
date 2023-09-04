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

// Returns only 1 item 
app.MapGet("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => 
{
    var tareaFromDB = dbContext.Tareas.Find(id);

    if (tareaFromDB == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(tareaFromDB);
});

// post implementation to create objects
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea ) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;

    // this is the first option, saving into the dbContext
    await dbContext.AddAsync(tarea);
    // the below is another option, this is the second option, using the Tareas first and then AddAsync
    // dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

// similar implementation to POST
app.MapPost("/api/tareas2", async ([FromServices] TareasContext dbContext, [FromBody] Tarea Tareas) =>
{
	Tareas.TareaId = Guid.NewGuid();
	Tareas.FechaCreacion = DateTime.Now;
	await dbContext.Tareas.AddAsync(Tareas);
	await dbContext.SaveChangesAsync();
	return Results.Ok(Tareas);
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

// Put Implementation
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => 
{
    var tareaFromDB = await dbContext.Tareas.FindAsync(id);

    if (tareaFromDB != null)
    {
        tareaFromDB.CategoriaId = tarea.CategoriaId;
        tareaFromDB.Titulo = tarea.Titulo;
        tareaFromDB.PrioridadTarea = tarea.PrioridadTarea;
        tareaFromDB.TareaCat = tarea.TareaCat;
        tareaFromDB.TareaNotes3 = tarea.TareaNotes3;
        tareaFromDB.Descripcion = tarea.Descripcion;
    }

    // await dbContext.Tareas.AddAsync(tareaFromDB);
    await dbContext.SaveChangesAsync();

    return Results.NotFound();
});


// app.MapPut("/api/tareas2/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tareas tareas, [FromRoute] Guid id) =>
// {
// 	var tarea = await dbContext.tareas.FindAsync(id);
// 	if (tarea == null)
// 	{
// 		return Results.NotFound();
// 	}
// 	tarea.Titulo = tareas.Titulo;
// 	tarea.Descripcion = tareas.Descripcion;
// 	tarea.PrioridadTarea = tareas.PrioridadTarea;
// 	tarea.Resumen = tareas.Resumen;
// 	tarea.CategoriaId = tareas.CategoriaId;
// 	await dbContext.SaveChangesAsync();

// 	return Results.Ok(tarea);
// });



app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => 
{

    var tareaFromDb = await dbContext.Tareas.FindAsync(id);

    if ( tareaFromDb == null )
    {
        return Results.NotFound();
    }

    dbContext.Tareas.Remove(tareaFromDb);
    dbContext.SaveChangesAsync();

    return Results.Ok();
});

// alternate delete implementation
// app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
// {
// 	var tarea = await dbContext.Tareas.FindAsync(id);
// 	if (tarea == null)
// 	{
// 		return Results.NotFound();
// 	}
// 	dbContext.Tareas.Remove(tarea);
// 	await dbContext.SaveChangesAsync();
// 	return Results.Ok(tarea);
// });



app.Run();

