using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.author.Application.DTO;
using TiendaServicios.api.author.Models;
using TiendaServicios.api.author.Persistence;

namespace TiendaServicios.api.author.Application
{
    public class FilterConsult
    {
        public class AuthorUnique : IRequest<AuthorDTO>
        {
            public string AuthorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AuthorUnique, AuthorDTO>
        {
            private readonly ContextAuthor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDTO> Handle(AuthorUnique request, CancellationToken cancellationToken)
            {
                var response = await _context.BookAuthor.Where(x => x.AuthorGuid == request.AuthorGuid)
                              .FirstOrDefaultAsync();

                if (response == null) throw new Exception("no data to display");

                var authorDto = _mapper.Map<Author, AuthorDTO>(response);

                return authorDto;
            }
        }
    }
}
