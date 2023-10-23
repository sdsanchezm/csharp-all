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
            // Create the database if it doesn't exist
            // Ensure creation of the database
            context.Database.EnsureCreated();

            // Seed the data
            // the content is seeded
            SeedData(context);

            // Query the data
            var results = context.Parents
                .Include(p => p.Child1)
                .Include(p => p.Child2)
                .ToList();

            // Output the results
            FiddleHelper.WriteTable(results);
        }
    }

    // Creating the Dbcontext
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>()
                .HasOne(p => p.Child1)
                .WithOne(c => c.Parent)
                .HasForeignKey<Child1>(c => c.ParentId);

            modelBuilder.Entity<Parent>()
                .HasOne(p => p.Child2)
                .WithOne(c => c.Parent)
                .HasForeignKey<Child2>(c => c.ParentId);
        }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child1> Children1 { get; set; }
        public DbSet<Child2> Children2 { get; set; }
    }

    // Creating Models
    public class Parent
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Child1 Child1 { get; set; }
        public Child2 Child2 { get; set; }
    }

    public class Child1
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }

    public class Child2
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }

    // Seeding data
    public static void SeedData(MyDbContext context)
    {
        var parent1 = new Parent { Name = "Parent 1" };
        var parent2 = new Parent { Name = "Parent 2" };

        var child1_1 = new Child1 { Name = "Child 1-1", Parent = parent1 };
        var child1_2 = new Child1 { Name = "Child 1-2", Parent = parent2 };

        var child2_1 = new Child2 { Name = "Child 2-1", Parent = parent1 };
        var child2_2 = new Child2 { Name = "Child 2-2", Parent = parent2 };

        context.Parents.AddRange(parent1, parent2);
        context.Children1.AddRange(child1_1, child1_2);
        context.Children2.AddRange(child2_1, child2_2);

        context.SaveChanges();
    }
}