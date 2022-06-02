using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Shop.Models;
using TiendaServicios.Api.Shop.Persistence;

namespace TiendaServicios.Api.Shop.Application
{
    public class Nuevo
    {

        public class Ejecuta : IRequest
        {
            public DateTime? FechaCreacion { get; set; }
            public List<string> ProductosSelected { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextShopping _context;

            public Manejador(ContextShopping context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var pedidoSesion = new PedidoSesion
                {
                    FechaCreacion = request.FechaCreacion
                };

                _context.PedidoSesion.Add(pedidoSesion);
                var value = await _context.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("no se inserto correctamente");
                }

                int id = pedidoSesion.PedidoSesionId;

                foreach (var item in request.ProductosSelected)
                {
                    var detalle = new PedidoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        PedidoSesionId = id,
                        ProductoSelected = item
                    };

                    _context.PedidoSesionDetalle.Add(detalle);
                }

                value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("no se pudo inserta detalle");
            }
        }
    }
}
