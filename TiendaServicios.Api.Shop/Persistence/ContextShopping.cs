using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Shop.Models;

namespace TiendaServicios.Api.Shop.Persistence
{
    public class ContextShopping : DbContext
    {
        public ContextShopping(DbContextOptions<ContextShopping> options) : base(options) { }
        public DbSet<PedidoSesion> PedidoSesion { get; set; }
        public DbSet<PedidoSesionDetalle> PedidoSesionDetalle { get; set; }
    }
}
