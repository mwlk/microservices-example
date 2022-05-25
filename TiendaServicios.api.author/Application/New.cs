using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.author.Models;
using TiendaServicios.api.author.Persistence;

namespace TiendaServicios.api.author.Application
{
    public class New
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        public class ExecuteValidations : AbstractValidator<Ejecuta>
        {
            public ExecuteValidations()
            {
                RuleFor(x => x.Nombre).NotEmpty().MinimumLength(3);
                RuleFor(x => x.Apellido).NotEmpty();
                
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {

            public readonly ContextAuthor _context;

            public Manejador(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var bookAuthor = new Author
                {
                    Name = request.Nombre,
                    LastName = request.Apellido,
                    BirthDate = request.FechaNacimiento,
                    AuthorGuid = Convert.ToString(Guid.NewGuid())
                };

                await _context.BookAuthor.AddAsync(bookAuthor);
                var value = await _context.SaveChangesAsync();

                if (value > 0) return Unit.Value;

                throw new Exception("no se pudo insertar el autor");

            }
        }
    }
}
