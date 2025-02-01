using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IUsuarioService usuarioService, IAutenticacaoService autenticacaoService)
        {
            _usuarioService = usuarioService;
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous] 
        public async Task<IActionResult> Login([FromBody] AutenticacaoLoginRequest request)
        {
            var resposta = await _autenticacaoService.Login(request);

            if (resposta == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = resposta });
        }

        [HttpPost("cadastro")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous] 
        public async Task<IActionResult> Criar([FromBody] UsuarioCriarAlterarRequest request)
        {
            var resposta = await _usuarioService.Criar(request);

            if(!resposta)
            {
                return UnprocessableEntity();
            }

            return Ok(resposta);
        }
    }
}
