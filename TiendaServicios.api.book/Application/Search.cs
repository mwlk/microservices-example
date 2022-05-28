using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.book.Application.DTO;
using TiendaServicios.api.book.Models;
using TiendaServicios.api.book.Persistence;

namespace TiendaServicios.api.book.Application
{
    public class Search
    {
        public class Ejecuta : IRequest<List<LibraryDto>>
        {

        }

        public class Manejador : IRequestHandler<Ejecuta, List<LibraryDto>>
        {
            private readonly LibraryContext _context;
            private readonly IMapper _mapper;

            public Manejador(LibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LibraryDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var result = await _context.Libreria.ToListAsync();

                return _mapper.Map<List<Library>, List<LibraryDto>>(result);
            }
        }
    }
}
