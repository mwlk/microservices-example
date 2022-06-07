using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Shop.Persistence;
using TiendaServicios.Api.Shop.RemoteInterface;

namespace TiendaServicios.Api.Shop.Application
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {

            public int CarritoSesionId { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly ContextShopping _context;
            private readonly ILibroService _service;

            public Manejador(ContextShopping context, ILibroService service)
            {
                _context = context;
                _service = service;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carrito = await _context.PedidoSesion.FirstOrDefaultAsync(x => x.PedidoSesionId == request.CarritoSesionId);

                var detalles = await _context.PedidoSesionDetalle.Where(x => x.PedidoSesionId == request.CarritoSesionId).ToListAsync();

                var listado = new List<CarritoDetalleDto>();

                foreach (var libro in detalles)
                {
                    var response = await _service.GetLibro(new Guid(libro.ProductoSelected));

                    if (response.result)
                    {
                        var objLibro = response.book;

                        var pedidoDetalle = new CarritoDetalleDto
                        {
                            Title = objLibro.Title,
                            FechaPublicacion = objLibro.PublicationDate,
                            LibraryId = objLibro.LibraryId
                        };

                        listado.Add(pedidoDetalle);
                    }
                }

                var carritoSesionDto = new CarritoDto
                {
                    ListaProductos = listado,
                    FechaCreacionSesion = carrito.FechaCreacion,
                    CarritoId = carrito.PedidoSesionId
                };

                return carritoSesionDto;
            }
        }
    }
}
