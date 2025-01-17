using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model;
using controle_financeiro_api.Service;
using Microsoft.AspNetCore.Mvc;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Model.DTO.Response;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpGet("{usuarioId}")]
        [ProducesResponseType(typeof(ReceitaDespesaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Listar([FromRoute] int usuarioId, [FromQuery] Mes mes)
        {
            return Ok(await _receitaService.Listar(usuarioId, mes));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Criar([FromBody] ReceitaCriarRequest request)
        {
            return Ok(await _receitaService.Criar(request));
        }
    }
}
