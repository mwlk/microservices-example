using System;

namespace TiendaServicios.Api.Shop.RemoteModel
{
    public class RemoteBook
    {
        public Guid? LibraryId { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Guid? AuthorBook { get; set; }
    }
}
