using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Models;
using controle_financeiro_api.Service;
using Microsoft.AspNetCore.Mvc;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Obter([FromRoute] int id)
        {
            return Ok(await _usuarioService.Obter(id));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Criar([FromBody] UsuarioCriarAlterarRequest request)
        {
            return Ok(await _usuarioService.Criar(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Alterar([FromRoute] int id, [FromBody] UsuarioCriarAlterarRequest request)
        {
            return Ok(await _usuarioService.Alterar(id, request));
        }

        [HttpPatch("adicionar-saldo/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AdicionarSaldo([FromRoute] int id, [FromBody] UsuarioAdicionarSaldoRequest request)
        {
            var response = await _usuarioService.AdicionarSaldo(id, request);

            if(response == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
