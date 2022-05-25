using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.author.Models;
using TiendaServicios.api.author.Persistence;

namespace TiendaServicios.api.author.Application
{
    public class Consult
    {
        public class AuthorList : IRequest<List<Author>> { }

        public class Manejador : IRequestHandler<AuthorList, List<Author>>
        {
            private readonly ContextAuthor _context;

            public Manejador(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<List<Author>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var list = await _context.BookAuthor.ToListAsync();

                return list;
            }
        }
    }
}
