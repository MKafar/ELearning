using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Assignments.Commands.CreateAssignment;
using ELearning.Application.Assignments.Commands.DeleteAssignment;
using ELearning.Application.Assignments.Commands.UpdateAssignment;
using ELearning.Application.Assignments.Queries.GetAssignmentById;
using ELearning.Application.Assignments.Queries.GetAssignmentsList;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class AssignmentsController : BaseController
    {
        // GET: api/Assignments/GetAll
        [HttpGet]
        public async Task<ActionResult<AssignmentsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAssignmentsListQuery()));
        }

        // GET: api/Assignments/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAssignmentByIdQuery { Id = id }));
        }

        // POST: api/Assignments/Create
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateAssignmentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Assignments/Update
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateAssignmentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Assignments/Delete/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAssignmentCommand { Id = id });

            return NoContent();
        }
    }
}
