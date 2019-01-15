using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Compiler.Commands.CompileCode;
using ELearning.Application.Compiler.Commands.SaveAssignmentSolution;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class CompilerController : BaseController
    {
        // POST: api/Compiler/run
        [HttpPost]
        [Authorize(Roles = Role.Student)]
        public async Task<ActionResult<string>> Run([FromBody] CompileCodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST: api/Compiler/send
        [HttpPost]
        [Authorize(Roles = Role.Student)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Send([FromBody] SaveAssignmentSolutionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
