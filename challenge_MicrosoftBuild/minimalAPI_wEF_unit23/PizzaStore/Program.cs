using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

// declaring builder
var builder = WebApplication.CreateBuilder(args);

// This is the connection string
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";

// this is the implementation for in-memory database
//builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));

// implementation to use the connection string for SQLite db
// This part requires the `dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0`
builder.Services.AddSqlite<PizzaDb>(connectionString);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pizza Store API",
        Description = "making pizza nicely",
        Version = "v1"
    });
});

// declaring app
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Store api v1");
});


// Endpoing here
app.MapGet("/", () => "Hello World!");
app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());

app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});



app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));

app.Run();
