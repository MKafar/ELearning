using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Groups.Commands.CreateGroup;
using ELearning.Application.Groups.Commands.DeleteGroup;
using ELearning.Application.Groups.Commands.UpdateGroup;
using ELearning.Application.Groups.Queries.GetGroupById;
using ELearning.Application.Groups.Queries.GetGroupSectionsListById;
using ELearning.Application.Groups.Queries.GetGroupsList;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class GroupsController : BaseController
    {
        // GET: api/Groups/GetAll
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<GroupsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetGroupsListQuery()));
        }

        // GET: api/Groups/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<GroupViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetGroupByIdQuery { Id = id }));
        }

        // GET: api/Groups/GetAllSectionsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<GroupSectionsListViewModel>> GetAllSectionsById(int id)
        {
            return Ok(await Mediator.Send(new GetGroupSectionsListByIdQuery { Id = id }));
        }

        // POST: api/Groups/Create
        [HttpPost]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateGroupCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Groups/Update
        [HttpPut]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateGroupCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Groups/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGroupCommand { Id = id });

            return NoContent();
        }
    }
}
