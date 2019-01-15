using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Sections.Commands.CreateSection;
using ELearning.Application.Sections.Commands.DeleteSection;
using ELearning.Application.Sections.Commands.UpdateSection;
using ELearning.Application.Sections.Queries.GetSectionById;
using ELearning.Application.Sections.Queries.GetSectionEvaluationsListById;
using ELearning.Application.Sections.Queries.GetSectionsList;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class SectionsController : BaseController
    {
        // GET: api/Sections/GetAll
        [HttpGet]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<SectionsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSectionsListQuery()));
        }

        // GET: api/Sections/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<SectionViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetSectionByIdQuery { Id = id }));
        }

        // GET: api/Sections/GetAllEvaluationsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<SectionEvaluationsListViewModel>> GetAllEvaluationsById(int id)
        {
            return Ok(await Mediator.Send(new GetSectionEvaluationsListByIdQuery { Id = id }));
        }

        // POST: api/Sections/Create
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateSectionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Sections/Update/5
        [HttpPut]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateSectionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Sections/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSectionCommand { Id = id });

            return NoContent();
        }
    }
}
