using System.Threading.Tasks;
using ELearning.Application.Auth.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AuthController : BaseController
    {
        // POST: api/Auth/login
        [HttpPost]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
