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

- Connection String is included in the **appsettings.json**
    - 
    ```cs
    "ConnectionStrings": {
    "connTareasdB": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=TareasDb;user id=admin;password=passHere"
    }
    ```
    - for windows authentication in MS SQL Studio
        ```cs
        "ConnectionStrings": {
            "cnTareas2":"Data Source=.\\SQLEXPRESS;Database=TareasDB;Integrated Security=True"
        }
        ```
        ```cs
        "connTareasdB": "Data Source=KRAUSXQ\\SQLEXPRESS;Initial Catalog=TareasDb1;user id=admin;password=passw0rd",
        "connTareasdB2": "Data Source=KRAUSXQ\\SQLEXPRESS;Initial Catalog=ToDosDb2;Trusted_Connection=True;TrustServerCertificate=true;"
        ```

- For the postgreSQL, the connection string is:
    - 
    ```cs
    //program.cs
    builder.Services.AddNpgsql<TaskContext>(builder.Configuration.GetConnectionString("TaskDb"));

    // appsettings.json
    "ConnectionStrings": {
        "TaskDb" :"Server=postgreServer;Database=StringEF;Port=5430;Username =my_user;Password=root;Host=localhost;",
        "DefaultConnection2": "Data Source=KRAUSP52\\SQLEXPRESS;Initial Catalog=pokeDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
        "connString1": "Data Source=KRAUSP52\\SQLEXPRESS;Initial Catalog=ToDosDataB1;Trusted_Connection=True;TrustServerCertificate=true;",
        "DefaultConnection2": "Data source=dbtest1.db"
    }
        ```

- DB Relations (Many to Many)
    - 1:1
    ```cs
    modelBuilder.Entity<Author>().HasOne(a => a.Biography).WithOne(b => b.Author).HasForeignKey<AuthorBiography>(b => b.AuthorRef);
    ```
    - N:N
    ```cs
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

- Install `entity SQLServer`
    - `dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.21`
        - from [https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/6.0.21]


- Create the initial migrations:
    - `dotnet ef migrations add InitialCreate`
- Add a migration
    - `dotnet ef migrations add MyMigration`
- Update db after migration
    - `dotnet ef database update`

- Migrations should be used in dev, is very difficult once the app is in production


## Blazor webassembly

- from cli
    - `dotnet new blazorwasm`
    - `dotnet build`
    - `dotnet run`

- `@page` : Ruta por donde va a ser accedido el componente.
- `<PageTitle>` Titulo de la pagina que aparece en el navegador.
- `@code{ }` Para escribir código C#, es el identificador para cuando se compile la aplicación; para dar notación que se refiere a C#.
- Example:
    - ```cs
        @page "/counter"
        <PageTitle>Counter</PageTitle>
        <h1>Counter</h1>
        <p role="status">Current count: @currentCount</p>
        <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

        @code {
            private int currentCount = 0;
            private void IncrementCount()
            {
                currentCount++;
            }
        }
    ```

## Misc Links
### MH Excercises

- [https://github.com/sheapa/StringExercises]
- [https://github.com/mossykazemi/CS-SolutionExamples/blob/master/Solution14/Program.cs]

### wpf course

- [https://github.com/OakAcademy/WPFPersonalTracking/blob/main/WPFPersonalTracking/WPFPersonalTracking/DB/Department.cs]

### MS learning applied skills certs

- [https://learn.microsoft.com/en-us/credentials/browse/?credential_types=applied%20skills]

### MISC Resources

- [https://www.go4expert.com/articles/c-sharp-tutorials/]
- [https://dotnet.microsoft.com/en-us/languages/csharp]
- [https://www.tutorialsteacher.com/csharp]
- [https://www.codecademy.com/learn/learn-c-sharp]
- [https://www.geeksforgeeks.org/csharp-programming-language/]
- [https://www.c-sharpcorner.com/]
- [https://dotnettutorials.net/lesson/dotnet-framework/]
- [https://codewithmosh.com/]
- [https://help.syncfusion.com/wpf/datagrid/styles-and-templates]
- [https://wpf-tutorial.com/wpf-application/resources/]


### MISC ghs

- [https://github.com/CSharpDesignPro/WPF---Responsive-UI-Design]
- [https://github.com/TacticDevGit/Record-Book-App-WPF-MVVM]
- [https://github.com/rmsmech/Tutorials/tree/master/WPF]





