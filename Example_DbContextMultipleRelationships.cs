using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static string ConnectionString = FiddleHelper.GetConnectionStringSqlServer();

    public static void Main()
    {
        using (var context = new MyDbContext())
        {
            // ensure database creation here
            context.Database.EnsureCreated();

            // Seed data here
            SeedData(context);

            // Query data, just creating a sample, instantiating the parent model
            var results = context.ParentModels
                .Include(p => p.ChildModel1)
                .Include(p => p.ChildModel2s)
                .Include(p => p.ChildModel3s)
                .ToList();

            // Displaying results here
            FiddleHelper.WriteTable(results);
        }
    }

    // This is the DbContext
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentModel>()
                .HasOne(p => p.ChildModel1)
                .WithOne(c => c.ParentModel)
                .HasForeignKey<ChildModel1>(c => c.ParentModelId);

            modelBuilder.Entity<ParentModel>()
                .HasMany(p => p.ChildModel2s)
                .WithOne(c => c.ParentModel)
                .HasForeignKey(c => c.ParentModelId);

            modelBuilder.Entity<ParentModel>()
                .HasMany(p => p.ChildModel3s)
                .WithMany(c => c.ParentModels)
                .UsingEntity<Dictionary<string, object>>(
                    "ParentModelChildModel3",
                    j => j
                        .HasOne<ChildModel3>()
                        .WithMany()
                        .HasForeignKey("ChildModel3Id")
                        .HasConstraintName("FK_ParentModelChildModel3_ChildModel3_ChildModel3Id")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<ParentModel>()
                        .WithMany()
                        .HasForeignKey("ParentModelId")
                        .HasConstraintName("FK_ParentModelChildModel3_ParentModel_ParentModelId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("ParentModelId", "ChildModel3Id");
                        j.HasIndex("ChildModel3Id").HasName("IX_ParentModelChildModel3_ChildModel3Id");
                    });
        }

        public DbSet<ParentModel> ParentModels { get; set; }
        public DbSet<ChildModel1> ChildModel1s { get; set; }
        public DbSet<ChildModel2> ChildModel2s { get; set; }
        public DbSet<ChildModel3> ChildModel3s { get; set; }
    }

    // ParentModel here
    public class ParentModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ChildModel1 ChildModel1 { get; set; }

        public List<ChildModel2> ChildModel2s { get; set; }

        public List<ChildModel3> ChildModel3s { get; set; }
    }

// ChildModel1
    public class ChildModel1
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentModelId { get; set; }
        public ParentModel ParentModel { get; set; }
    }

// ChildModel2
    public class ChildModel2
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentModelId { get; set; }
        public ParentModel ParentModel { get; set; }
    }

// ChildModel3
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ParentModel> ParentModels { get; set; }
    }

    // Seeding the data here
    public static void SeedData(MyDbContext context)
    {
        var parentModel = new ParentModel { Name = "Parent Model" };
        var childModel1 = new ChildModel1 { Name = "Child Model 1", ParentModel = parentModel };
        var childModel2_1 = new ChildModel2 { Name = "Child Model 2-1", ParentModel = parentModel };
        var childModel2_2 = new ChildModel2 { Name = "Child Model 2-2", ParentModel = parentModel };
        var childModel3_1 = new ChildModel3 { Name = "Child Model 3-1" };
        var childModel3_2 = new ChildModel3 { Name = "Child Model 3-2" };

        parentModel.ChildModel1 = childModel1;
        parentModel.ChildModel2s = new List<ChildModel2> { childModel2_1, childModel2_2 };
        parentModel.ChildModel3s = new List<ChildModel3> { childModel3_1, childModel3_2 };

        context.ParentModels.Add(parentModel);
        context.ChildModel1s.Add(childModel1);
        context.ChildModel2s.AddRange(childModel2_1, childModel2_2);
        context.ChildModel3s.AddRange(childModel3_1, childModel3_2);

        context.SaveChanges();
    }
}
