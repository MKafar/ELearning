using System.Threading.Tasks;
using ELearning.Application.Users.Queries.GetUsersList;
using ELearning.Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ELearning.Application.Users.Command.CreateUser;
using ELearning.Application.Users.Command.UpdateUser;
using ELearning.Application.Users.Command.DeleteUser;
using ELearning.Application.Users.Queries.GetSectionsListById;
using ELearning.Application.Users.Queries.GetAssignmentsListWithDetailsById;
using ELearning.Application.Users.Queries.GetStudentsList;
using ELearning.Application.Users.Queries.GetPastAssignmentsListById;

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

        // GET: api/Users/GetAllStudents/
        [HttpGet]
        public async Task<ActionResult<StudentsListViewModel>> GetAllStudents()
        {
            return Ok(await Mediator.Send(new GetStudentsListQuery()));
        }

        // GET: api/Users/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        // GET: api/Users/GetAllSectionsById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionsDetailedListViewModel>> GetAllSectionsById(int id)
        {
            return Ok(await Mediator.Send(new GetSectionsListByIdQuery { Id = id }));
        }

        // GET: api/Users/GetAllAssignmentsWithDetailsById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentsListWithDetailsViewModel>> GetAllAssignmentsWithDetailsById(int id)
        {
            return Ok(await Mediator.Send(new GetAssignmentsListWithDetailsByIdQuery { Id = id }));
        }

        // GET: api/Users/GetAllPastAssignmentsById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PastAssignmentsListViewModel>> GetAllPastAssignmentsById(int id)
        {
            return Ok(await Mediator.Send(new GetPastAssignmentsListByIdQuery { Id = id }));
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
