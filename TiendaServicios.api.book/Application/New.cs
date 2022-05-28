using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.book.Models;
using TiendaServicios.api.book.Persistence;

namespace TiendaServicios.api.book.Application
{
    public class New : IRequest
    {


        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? Publication { get; set; }
            public Guid? BookAuthor { get; set; }
        }

        public class ValidateExecute : AbstractValidator<Execute>
        {
            public ValidateExecute()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Publication).NotEmpty();
                RuleFor(x => x.BookAuthor).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Execute>
        {
            private readonly LibraryContext _context;
            public Manejador(LibraryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new Library
                {
                    AuthorBook = request.BookAuthor,
                    PublicationDate = request.Publication,
                    Title = request.Title
                };

                _context.Libreria.Add(book);

                var value = await _context.SaveChangesAsync();

                if (value > 0) return Unit.Value;

                throw new Exception("insert no avalaible");
            }
        }
    }
}
