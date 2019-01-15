using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Subjects.Command.CreateSubject;
using ELearning.Application.Subjects.Command.DeleteSubject;
using ELearning.Application.Subjects.Command.UpdateSubject;
using ELearning.Application.Subjects.Queries.GetSubjectById;
using ELearning.Application.Subjects.Queries.GetSubjectGroupsListById;
using ELearning.Application.Subjects.Queries.GetSubjectsList;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class SubjectsController : BaseController
    {
        // GET: api/Subjects/GetAll
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<SubjectsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSubjectsListQuery()));
        }

        // GET: api/Subjects/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<SubjectViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetSubjectByIdQuery { Id = id }));
        }

        // GET: api/Subjects/GetAllGroupsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<SubjectGroupsListViewModel>> GetAllGroupsById(int id)
        {
            return Ok(await Mediator.Send(new GetSubjectGroupsListByIdQuery { Id = id }));
        }

        // POST: api/Subjects/Create
        [HttpPost]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateSubjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Subjects/Update
        [HttpPut]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateSubjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSubjectCommand { Id = id });

            return NoContent();
        }
    }
}
