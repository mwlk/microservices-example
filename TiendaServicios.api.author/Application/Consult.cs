using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.author.Application.DTO;
using TiendaServicios.api.author.Models;
using TiendaServicios.api.author.Persistence;

namespace TiendaServicios.api.author.Application
{
    public class Consult
    {
        public class AuthorList : IRequest<List<AuthorDTO>> { }

        public class Manejador : IRequestHandler<AuthorList, List<AuthorDTO>>
        {
            private readonly ContextAuthor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<AuthorDTO>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var list = await _context.BookAuthor.ToListAsync();

                var autoresDto = _mapper.Map<List<Author>, List<AuthorDTO>>(list);

                return autoresDto;
            }
        }
    }
}
