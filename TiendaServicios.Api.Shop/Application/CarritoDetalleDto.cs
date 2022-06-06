using System;

namespace TiendaServicios.Api.Shop.Application
{
    public class CarritoDetalleDto
    {

        public Guid? LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? FechaPublicacion { get; set; }
    }
}
