using System;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

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
            Env.Load();
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            optionsBuilder.UseMySql(connectionString, 
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
