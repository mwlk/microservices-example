using System;
using System.Collections.Generic;

namespace TiendaServicios.Api.Shop.Models
{
    public class PedidoSesion
    {
        public int PedidoSesionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public ICollection<PedidoSesionDetalle> Detalle { get; set; }
    }
}
