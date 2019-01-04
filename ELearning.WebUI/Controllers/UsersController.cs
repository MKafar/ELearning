using System.Threading.Tasks;
using ELearning.Application.Users.Queries.GetUsersList;
using ELearning.Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ELearning.Application.Users.Command.CreateUser;
using ELearning.Application.Users.Command.UpdateUser;
using ELearning.Application.Users.Command.DeleteUser;
using ELearning.Application.Users.Queries.GetUserSectionsListById;
using ELearning.Application.Users.Queries.GetUserAssignmentsListWithDetailsById;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class UsersController : BaseController
    {
        // GET: api/Users/GetAll
        [HttpGet]
        public async Task<ActionResult<UsersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        // GET: api/Users/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        // GET: api/Users/GetAllSectionsById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSectionsListViewModel>> GetAllSectionsById(int id)
        {
            return Ok(await Mediator.Send(new GetUserSectionsListByIdQuery { Id = id }));
        }

        // GET: api/Users/GetAllAssignmentsWithDetailsById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAssignmentsListWithDetailsViewModel>> GetAllAssignmentsWithDetailsById(int id)
        {
            return Ok(await Mediator.Send(new GetUserAssignmentsListWithDetailsByIdQuery { Id = id }));
        }

        // POST: api/Users/Create
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Users/Update
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Users/Delete/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}
