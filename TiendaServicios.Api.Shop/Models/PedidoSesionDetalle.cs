using System;

namespace TiendaServicios.Api.Shop.Models
{
    public class PedidoSesionDetalle
    {
        public int PedidoSesionDetalleId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ProductoSelected { get; set; }
        public int PedidoSesionId { get; set; }
        public PedidoSesion PedidoSesion { get; set; }
    }
}
