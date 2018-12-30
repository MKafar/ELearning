using System.Threading.Tasks;
using ELearning.Application.Users.Queries.GetUsersList;
using ELearning.Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ELearning.Application.Users.Command.CreateUser;
using ELearning.Application.Users.Command.UpdateUser;
using ELearning.Application.Users.Command.DeleteUser;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class UsersController : BaseController
    {
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<UsersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}
