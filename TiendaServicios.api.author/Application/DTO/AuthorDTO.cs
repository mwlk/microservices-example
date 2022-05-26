using System;

namespace TiendaServicios.api.author.Application.DTO
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string AuthorGuid { get; set; }
    }
}
