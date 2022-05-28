using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.api.book.Application.DTO;
using TiendaServicios.api.book.Models;
using TiendaServicios.api.book.Persistence;

namespace TiendaServicios.api.book.Application
{
    public class FilteredSearch
    {
        public class UniqueBook : IRequest<LibraryDto>
        {
            public Guid? BookId { get; set; }
        }

        public class Handler : IRequestHandler<UniqueBook, LibraryDto>
        {
            private readonly LibraryContext _context;
            private readonly IMapper _mapper;

            public Handler(LibraryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LibraryDto> Handle(UniqueBook request, CancellationToken cancellationToken)
            {
                var book = await _context.Libreria.Where(x => x.LibraryId == request.BookId).FirstOrDefaultAsync();

                if (book != null) return _mapper.Map<Library, LibraryDto>(book);

                throw new Exception("cant find");
            }
        }
    }
}
