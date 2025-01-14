using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Models;
using controle_financeiro_api.Service;
using Microsoft.AspNetCore.Mvc;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaService _despesaService;

        public DespesaController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpGet("{usuarioId}")]
        [ProducesResponseType(typeof(Despesa), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Obter([FromRoute] int usuarioId)
        {
            return Ok(await _despesaService.Obter(usuarioId));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Criar([FromBody] DespesaCriarRequest request)
        {
            return Ok(await _despesaService.Criar(request));
        }
    }
}
