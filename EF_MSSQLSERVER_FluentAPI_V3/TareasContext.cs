using ef_api5.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_api5;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriaInit = new List<Categoria>();

        categoriaInit.Add( new Categoria() { CategoriaID = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597947"), Nombre = "Pendings" } );
        categoriaInit.Add( new Categoria() { CategoriaID = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597948"), Nombre = "Not important" } );

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoriax");
            categoria.HasKey(p => p.CategoriaID);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            // categoria.Property(p => p.Descripcion);
            categoria.Property(p => p.Descripcion).IsRequired(false);

            categoria.HasData(categoriaInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add( new Tarea() { TareaId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597988"), CategoriaId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597947"), Titulo = "task-1", TareaNotes3 = "ads3", TareaCat = "this is tarea Cat", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now } );
        tareasInit.Add( new Tarea() { TareaId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597990"), CategoriaId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597948"), Titulo = "task-2", TareaNotes3 = "qwe3", TareaCat = "this is tarea Cat", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now } );

        modelBuilder.Entity<Tarea>(Tarea =>
        {
            Tarea.ToTable("Tareax");
            Tarea.HasKey(p => p.TareaId);
            // CategoriaID comes from the Categoria Table
            Tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            Tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            Tarea.Property(p => p.Descripcion).IsRequired(false);
            Tarea.Property(p => p.TareaNotes3);
            Tarea.Property(p => p.TareaCat);
            Tarea.Property(p => p.PrioridadTarea);
            Tarea.Property(p => p.FechaCreacion);
            Tarea.Ignore(p => p.Resumen); // this field is internal
            
            Tarea.HasData(tareasInit);
        });


    }
}


