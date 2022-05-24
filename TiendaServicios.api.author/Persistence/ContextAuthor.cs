using Microsoft.EntityFrameworkCore;
using TiendaServicios.api.author.Models;

namespace TiendaServicios.api.author.Persistence
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options)
        {

        }

        public DbSet<Author> BookAuthor { get; set; }
        public DbSet<GradoAcademico> AcademicDegree { get; set; }
    }
}
