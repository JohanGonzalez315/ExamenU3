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
        public DbSet<Pedido> Pedidos { get; set; }
        
        public DbSet<Category> ? Categories {get; set;}
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

        public DbSet<Client> ? Clients {get; set;}

        protected void onModelCreatingClient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    Id = 1,
                    Nombre = "Test",
                    Apellidos = "Test",
                    RFC = "100",
                    CorreoElectronico = "20203tn132@utez.edu.mx",
                    Telefono ="7771367133"
                }
            );
        }
    }
}