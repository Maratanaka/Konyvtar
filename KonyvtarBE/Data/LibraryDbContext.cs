using Konyvtar.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Konyvtar.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }


        public DbSet<Book> Books => Set<Book>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Price precision
            modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasPrecision(18, 2);


            // Unique ISBN index
            modelBuilder.Entity<Book>()
            .HasIndex(b => b.ISBN)
            .IsUnique();


            // Seed data
            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Egri csillagok",
                Author = "Gárdonyi Géza",
                ISBN = "1234567890123",
                PublishedYear = 1901,
                Price = 3500.00m,
                InStock = true,
                CreatedAt = DateTime.UtcNow
            },
            new Book
            {
                Id = 2,
                Title = "A Pál utcai fiúk",
                Author = "Molnár Ferenc",
                ISBN = "9876543210987",
                PublishedYear = 1907,
                Price = 2800.50m,
                InStock = true,
                CreatedAt = DateTime.UtcNow
            },
            new Book
            {
                Id = 3,
                Title = "Az ember tragédiája",
                Author = "Madách Imre",
                ISBN = "4567891234567",
                PublishedYear = 1861,
                Price = 4200.75m,
                InStock = false,
                CreatedAt = DateTime.UtcNow
            },
            new Book
            {
                Id = 4,
                Title = "Tüskevár",
                Author = "Fekete István",
                ISBN = "3216549870123",
                PublishedYear = 1957,
                Price = 3100.00m,
                InStock = true,
                CreatedAt = DateTime.UtcNow
            }
            );
        }
    }
}
