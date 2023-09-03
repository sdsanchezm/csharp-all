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

- Many to Many relationship 
    - [https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration]


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

- DB Relations (Many to Many)
    - 1:1
    ```
    modelBuilder.Entity<Author>().HasOne(a => a.Biography).WithOne(b => b.Author).HasForeignKey<AuthorBiography>(b => b.AuthorRef);
    ```
    - N:N
    ```
    modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });
    modelBuilder.Entity<BookCategory>().HasOne(bc => bc.Book).WithMany(b => b.BookCategories).HasForeignKey(bc => bc.BookId);
    modelBuilder.Entity<BookCategory>().HasOne(bc => bc.Category).WithMany(c => c.BookCategories).HasForeignKey(bc => bc.CategoryId);
    ```


## Migrations

- Install `dotnet ef`
    - `dotnet tool install --global dotnet-ef --version 6.0.21`
        - from [https://www.nuget.org/packages/dotnet-ef/]

- Install `dotnet design`
    - `dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.21`
    - `dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3`
        - from [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/6.0.21]

- Create the initial migrations:
    - `dotnet ef migrations add InitialCreate`
- Add a migration
    - `dotnet ef migrations add MyMigration`
- Update db after migration
    - `dotnet ef database update`

- Migrations should be used in dev, is very difficult once the app is in production










