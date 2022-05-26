using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaServicios.api.author.Application;
using TiendaServicios.api.author.Application.DTO;
using TiendaServicios.api.author.Models;

namespace TiendaServicios.api.author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAuthors()
        {
            return await _mediator.Send(new Consult.AuthorList());
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<AuthorDTO>> GetBookAuthorFiltered(string uid)
        {
            return await _mediator.Send(new FilterConsult.AuthorUnique { AuthorGuid = uid });
        }
    }
}
