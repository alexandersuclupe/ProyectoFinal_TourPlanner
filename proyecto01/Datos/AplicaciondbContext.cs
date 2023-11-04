using Microsoft.EntityFrameworkCore;
using proyecto01.Models;

namespace proyecto01.Datos
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext>options) : base(options)
        {
            
        }
        //Agergar el modelo categoria a nuestro DbContext
        public DbSet<Categoria> Categoria { get; set; }
    }
}
