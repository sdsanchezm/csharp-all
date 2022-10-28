using ef_api5.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_api5;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaID);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
        });

        modelBuilder.Entity<Tarea>(Tarea => {
            Tarea.ToTable("Tarea");
            Tarea.HasKey(p => p.TareaId);
            // CategoriaID comes from the Categoria Table
            Tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            Tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            Tarea.Property(p => p.Descripcion);
            Tarea.Property(p => p.PrioridadTarea);
            Tarea.Property(p => p.FechaCreacion);
            Tarea.Ignore(p => p.Resumen);
        });
    }
}


