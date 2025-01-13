using Microsoft.AspNetCore.Mvc;

namespace controle_financeiro_api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorld : ControllerBase
    { 
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok("Hello World!!!! 🤗");
        }
    }
}
