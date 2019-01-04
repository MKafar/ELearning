using System.Threading.Tasks;
using ELearning.Application.Compiler.Commands.CompileCode;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class CompilerController : BaseController
    {
        // POST: api/Compiler
        [HttpPost]
        public async Task<ActionResult<string>> Run([FromBody] CompileCodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
