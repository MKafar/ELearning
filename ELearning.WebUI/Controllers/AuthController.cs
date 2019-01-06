using System.Threading.Tasks;
using ELearning.Application.Auth.Login;
using ELearning.Common;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        // POST: api/Auth/login
        [HttpPost]
        public async Task<ActionResult<AuthData>> Login([FromBody] LoginCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
