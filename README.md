# csharp-all
Csharp Learning process


## EF Documentation

- [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.21](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.21)

- in [nuget.org] install:
- Microsoft.EntityFrameworkCore 6.0.10
    - [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.10]
    - dotnet add package Microsoft.EntityFrameworkCore --version 6.0.10

- EF in Memory
    - [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.InMemory/6.0.10]
    - dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.10

- EF SQL Server
    - [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.10]
    - dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.10

- SQL Server Express:
    - [https://www.microsoft.com/en-ca/sql-server/sql-server-downloads]

- MS SQL Studio:
    - [https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms]



## Entity Framework

- Models in ./Models
- Create a context
    - The name should be TaskContext.cs (the name of the project and the word "Context")

- EF configuration
    - It requires a context
    - relation of models get transformed into collections that are sent to the database
    - Example of a context
        ```cs
        using Microsoft.EntityFrameworkCore;
        using projectef.models;

        namespace TaskContext;

        public class TaskContext : DbContext
        {

            public DbSet<Category> categories { get; set; }
            public DbSet<Homework> homeworks { get; set; }

            public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        }
        ```
    - Model is named singular
    - Context is plural

- in models, `using System.ComponentModel.DataAnnotations;` defines [key] in the model structure
- Data Notations:
    - [NotMapped]
    - [Required]
    - [MaxLength(150)]
    - [Key]
    - [ForeignKey("CategoriaId")]

- Connection String is included in the appsettings.json
    - 
        ```
        "ConnectionStrings": {
        "connTareasdB": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TareasDb;user id=admin;password=passHere"
        }
        ```
    - for windows authentication in MS SQL Studio
        ```
        "ConnectionStrings": {
            "cnTareas":"Data Source=.\\SQLEXPRESS;Database=TareasDB;Integrated Security=True"
        }
        ```

- For the postgreSQL, the connection string is:
    - 
        ```
        //program.cs
        builder.Services.AddNpgsql<TaskContext>(builder.Configuration.GetConnectionString("TaskDb"));

        // appsettings.json
        "ConnectionStrings": {
            "TaskDb" :"Server=postgreServer;Database=StringEF;Port=5430;Username =my_user;Password=root;Host=localhost;"
        }
        ```







