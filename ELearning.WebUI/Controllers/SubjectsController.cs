using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Subjects.Command.CreateSubject;
using ELearning.Application.Subjects.Command.DeleteSubject;
using ELearning.Application.Subjects.Command.UpdateSubject;
using ELearning.Application.Subjects.Queries.GetSubjectById;
using ELearning.Application.Subjects.Queries.GetSubjectsList;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class SubjectsController : BaseController
    {
        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<SubjectsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSubjectsListQuery()));
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetSubjectByIdQuery { Id = id }));
        }

        // POST: api/Subjects
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateSubjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Subjects/5
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateSubjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSubjectCommand { Id = id });

            return NoContent();
        }
    }
}
