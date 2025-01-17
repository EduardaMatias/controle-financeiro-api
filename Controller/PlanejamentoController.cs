using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Models;
using controle_financeiro_api.Service;
using Microsoft.AspNetCore.Mvc;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanejamentoController : ControllerBase
    {
        private readonly IPlanejamentoService _planejamentoService;

        public PlanejamentoController(IPlanejamentoService planejamentoService)
        {
            _planejamentoService = planejamentoService;
        }

        [HttpGet("{usuarioId}")]
        [ProducesResponseType(typeof(Planejamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Obter([FromRoute] int usuarioId, [FromQuery] Mes mes)
        {
            return Ok(await _planejamentoService.Obter(usuarioId, mes.ToString()));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Criar([FromBody] PlanejamentoCriarRequest request)
        {
            var resposta = await _planejamentoService.Criar(request);

            if(!resposta)
            {
                return BadRequest();
            }

            return Ok(resposta);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Alterar([FromRoute] int id, [FromBody] PlanejamentoAlterarRequest request)
        {
            return Ok(await _planejamentoService.Alterar(id, request));
        }
    }
}
