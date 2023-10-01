using Microsoft.EntityFrameworkCore;
using TiendaAPI.Entities;

namespace TiendaAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
    }
}
