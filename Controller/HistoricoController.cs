using controle_financeiro_api.Model;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Service;
using Microsoft.AspNetCore.Mvc;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoService _historicoService;

        public HistoricoController(IHistoricoService historicoService)
        {
            _historicoService = historicoService;
        }

        [HttpGet("{usuarioId}")]
        [ProducesResponseType(typeof(IEnumerable<Historico>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Listar([FromRoute] int usuarioId, [FromQuery] Mes mes)
        {
            return Ok(await _historicoService.Listar(usuarioId, mes));
        }
    }
}
