using Microsoft.EntityFrameworkCore;
using proyecto01.Models;

namespace proyecto01.Datos
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext>options) : base(options)
        {
            
        }
        //Agregar el modelo categoria a nuestro DbContext
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }

    }
}
