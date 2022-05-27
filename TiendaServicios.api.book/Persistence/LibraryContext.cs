using Microsoft.EntityFrameworkCore;
using TiendaServicios.api.book.Models;

namespace TiendaServicios.api.book.Persistence
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Library> Libreria { get; set; }
    }
}
