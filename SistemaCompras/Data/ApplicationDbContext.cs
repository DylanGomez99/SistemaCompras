using Microsoft.EntityFrameworkCore;
using SistemaCompras.Models;

namespace SistemaCompras.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<SolicitudCompra> SolicitudesCompra { get; set; }
        public DbSet<DetalleSolicitudCompra> DetallesSolicitudCompra { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<DetalleOrdenCompra> DetallesOrdenCompra { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}