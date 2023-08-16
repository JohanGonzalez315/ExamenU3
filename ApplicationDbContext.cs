using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ExamenU3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
            
        }

        public DbSet<Product> ? Products {get; set;}

        protected void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Nombre = "Test",
                    Descripcion = "Test",
                    Precio = "100",
                    Cantidad = 2
                }
            );
        }
    }
}