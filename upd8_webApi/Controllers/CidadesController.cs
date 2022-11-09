using Microsoft.AspNetCore.Mvc;
using upd8_webApi.DTO.Resposta;
using upd8_webApi.DTO.Solicitação;
using upd8_webApi.Models;
using upd8_webApi.Services.Interfaces;

namespace upd8_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;

        public CidadesController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        // GET: api/Cidades
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CidadeDTO>))]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidade()
        {
            var cidades = await _cidadeService.GetCidades();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cidades);

        }

        // GET: api/Cidades/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CidadeDTO))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Cidade>> GetCidade(int cidadeId)
        {
            if (!_cidadeService.CidadeExists(cidadeId))
                return NotFound();

            var pedido = await _cidadeService.GetCidade(cidadeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pedido);
        }

        // PUT: api/Cidades/5

        [HttpPut("{cidadeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCidade(int cidadeId, [FromBody] CidadeDTO cidade)
        {
            if (cidade == null)
                return BadRequest(ModelState);

            if (cidadeId != cidade.CidadeId)
                return BadRequest(ModelState);

            var cidadeUpdated = _cidadeService.UpdateCidade(cidade);

            if (!cidadeUpdated)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // POST: api/Cidades
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCidade([FromBody] CidadeSolicitacaoDto cidade)
        {
            if (cidade == null)
                return BadRequest(ModelState);

            var cidadeCreated = _cidadeService.CreateCidade(cidade);

            if (!cidadeCreated)
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();
        }

        // DELETE: api/Cidades/5
        [HttpDelete("{cidadeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCidade(int cidadeId)
        {
            if (!_cidadeService.CidadeExists(cidadeId))
            {
                return NotFound();
            }

            var pedidoToDelete = await _cidadeService.DeleteCidade(cidadeId);

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
