using System;

namespace TiendaServicios.api.book.Models
{
    public class Library
    {
        public Guid? LibraryGuidId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? AuthorBook { get; set; }

    }
}
