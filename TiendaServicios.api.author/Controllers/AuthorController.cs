using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaServicios.api.author.Application;

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
    }
}
