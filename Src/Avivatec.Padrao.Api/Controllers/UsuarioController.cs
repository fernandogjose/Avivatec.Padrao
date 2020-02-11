using System.Collections.Generic;
using System.Threading.Tasks;
using Avivatec.Padrao.Application.Cqrs.Common;
using Avivatec.Padrao.Application.Cqrs.Usuarios.Commands.AdicionarUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avivatec.Padrao.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator) => _mediator = mediator;

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/v1.0/Usuario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarUsuarioCommand adicionarUsuarioCommand)
        {
            BaseResponse adicionarUsuarioResponse = await _mediator.Send(adicionarUsuarioCommand);

            return StatusCode((int)adicionarUsuarioResponse.StatusCode, adicionarUsuarioResponse);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
