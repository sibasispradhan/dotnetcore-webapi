using System;
using Microsoft.EntityFrameworkCore;

namespace TestDbConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql("Server=7hx.h.filess.io;Port=3307;Database=careersdb_government;User=careersdb_government;Password=9bf2f924f0e504f8167f69512fe39ce2868802a9;", 
                                    new MySqlServerVersion(new Version(8, 0, 21)));

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                try
                {
                    context.Database.OpenConnection();
                    Console.WriteLine("Database connection succeeded!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed: {ex.Message}");
                }
            }
        }
    }
}
