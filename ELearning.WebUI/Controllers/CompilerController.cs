using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.Application.Compiler.Commands.CompileCode;
using Microsoft.AspNetCore.Http;
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

        // PUT: api/Compiler/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
