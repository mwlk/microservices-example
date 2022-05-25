using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.author.Models;
using TiendaServicios.api.author.Persistence;

namespace TiendaServicios.api.author.Application
{
    public class FilterConsult
    {
        public class AuthorUnique : IRequest<Author>
        {
            public string AuthorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AuthorUnique, Author>
        {
            private readonly ContextAuthor _context;

            public Manejador(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<Author> Handle(AuthorUnique request, CancellationToken cancellationToken)
            {
                var response = await _context.BookAuthor.Where(x => x.AuthorGuid == request.AuthorGuid)
                              .FirstOrDefaultAsync();

                if (response == null) throw new Exception("no data to display");

                return response;
            }
        }
    }
}
