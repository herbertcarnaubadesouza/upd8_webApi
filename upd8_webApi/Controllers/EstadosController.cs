using Microsoft.AspNetCore.Mvc;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;
using upd8_webApi.Services.Interfaces;

namespace upd8_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadosController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        // GET: api/Estados
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EstadoDTO>))]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
        {
            var Estados = await _estadoService.GetEstados();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Estados);

        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(EstadoDTO))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Estado>> GetEstado(int EstadoId)
        {
            if (!_estadoService.EstadoExists(EstadoId))
                return NotFound();

            var pedido = await _estadoService.GetEstado(EstadoId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedido);
        }

        // PUT: api/Estados/5

        [HttpPut("{EstadoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEstado(int EstadoId, [FromBody] EstadoDTO Estado)
        {
            if (Estado == null)
                return BadRequest(ModelState);

            if (EstadoId != Estado.EstadoId)
                return BadRequest(ModelState);

            var EstadoUpdated = _estadoService.UpdateEstado(Estado);

            if (!EstadoUpdated)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // POST: api/Estados
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEstado([FromBody] EstadoSolicitacaoDto Estado)
        {
            if (Estado == null)
                return BadRequest(ModelState);

            var EstadoCreated = _estadoService.CreateEstado(Estado);

            if (!EstadoCreated)
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // DELETE: api/Estados/5
        [HttpDelete("{EstadoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteEstado(int EstadoId)
        {
            if (!_estadoService.EstadoExists(EstadoId))
            {
                return NotFound();
            }

            var pedidoToDelete = await _estadoService.DeleteEstado(EstadoId);

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
