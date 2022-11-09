using Microsoft.AspNetCore.Mvc;
using Servicos.Interfaces;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;

namespace upd8_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }
        
        // GET: api/Clientes
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes([FromQuery] ClienteSolicitacaoDto clientesQuery)
        {
            var clientes = await _clientesService.GetClientes(clientesQuery);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(clientes);
        }

        // GET: api/Clientes/5
        [HttpGet("{clienteId}")]
        public async Task<ActionResult<Cliente>> GetCliente(int clienteId)
        {
            if (!_clientesService.ClienteExists(clienteId))
                return NotFound();

            var cliente = await _clientesService.GetCliente(clienteId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{clienteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCliente(int clienteId, [FromBody]Cliente cliente)
        {
            if (cliente == null)
                return BadRequest(ModelState);

            if (clienteId != cliente.ClienteId)
                return BadRequest(ModelState);

            var clienteUpdated = _clientesService.UpdateCliente(cliente);

            if (!clienteUpdated)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest(ModelState);

            var clienteCreated = _clientesService.CreateCliente(cliente);

            if (!clienteCreated)
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{clienteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCliente(int clienteId)
        {
            if (!_clientesService.ClienteExists(clienteId))
            {
                return NotFound();
            }

            var pedidoToDelete = await _clientesService.DeleteCliente(clienteId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!pedidoToDelete)
            {
                ModelState.AddModelError("", "Something went wrong deleting pedido");
            }

            return NoContent();
        }        
    }
}
