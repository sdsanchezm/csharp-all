using Microsoft.OpenApi.Models;
using PizzaStore.DB;
//using System.Data;

// declaration of builder here
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "pizzaStore API", Description = "making pizza yeah", Version = "v1" });
});

// declaration of app here
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "pizza API V1");
});

//var datatest =
//{
//    "name": "asd",
//    "zxc" = 44
//}

app.MapGet("/", () => "Hello World!");
//app.MapGet("/datatest", () => datatest);

// GET
//app.MapGet("/products/{id}", (int id) => data.SingleOrDefault(product => product.Id == id));

// POST
//app.MapPost("/products", (Product product) => /**/);
//public record Product(int Id, string Name);


// PUT
//app.MapPut("/products", (Product product) => /* Update the data store using the `product` instance */);


// DELETE
//app.MapDelete("/products/{id}", (int id) => /* Remove the record whose unique identifier matches `id` */);


// RESPONSES
// app.MapGet("/products", () => products);
//[{
//  "id": 1,
//  "name": "a product"
//}, {
//    "id": 2,
//  "name": "another product"
//}]

//// app.MapGet("/products/{id}", (int id) => products.SingleOrDefault(product => product.Id == id));
//[{
//  "id": 1,
//  "name": "a product"
//}]

//// app.MapGet("/product", () => new { id = 1 });
//{
//    "id": 1
//}



// app.MapGet("/todos", await (TodoDb db) => db.Todos.ToListAsync());
//app.MapPost("/todos", await (Todo todo) => { });
//app.MapPut("/todos", (Todo todo) => { });
//app.MapDelete("/todos/{id}", (int id) => { });


app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));


app.Run();
