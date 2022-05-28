using System;

namespace TiendaServicios.api.book.Application.DTO
{
    public class LibraryDto
    {
        public Guid? LibraryId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}
