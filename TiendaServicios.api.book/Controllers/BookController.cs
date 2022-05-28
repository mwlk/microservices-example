using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicios.api.book.Application;
using TiendaServicios.api.book.Application.DTO;

namespace TiendaServicios.api.book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Insert(New.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibraryDto>>> GetAll()
        {
            return await _mediator.Send(new Search.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDto>> GetBookById(Guid id)
        {
            return await _mediator.Send(new FilteredSearch.UniqueBook { BookId = id });
        }
    }
}
