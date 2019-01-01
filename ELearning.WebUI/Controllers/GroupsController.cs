using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Groups.Commands.CreateGroup;
using ELearning.Application.Groups.Commands.DeleteGroup;
using ELearning.Application.Groups.Commands.UpdateGroup;
using ELearning.Application.Groups.Queries.GetGroupById;
using ELearning.Application.Groups.Queries.GetGroupsList;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class GroupsController : BaseController
    {
        // GET: api/Groups/GetAll
        [HttpGet]
        public async Task<ActionResult<GroupsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetGroupsListQuery()));
        }

        // GET: api/Groups/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetGroupByIdQuery { Id = id }));
        }

        // POST: api/Groups/Create
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateGroupCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Groups/Update
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateGroupCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Groups/Delete/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGroupCommand { Id = id });

            return NoContent();
        }
    }
}
