using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Evaluations.Commands.CreateEvaluation;
using ELearning.Application.Evaluations.Commands.DeleteEvaluation;
using ELearning.Application.Evaluations.Commands.UpdateEvaluation;
using ELearning.Application.Evaluations.Queries.GetEvaluationById;
using ELearning.Application.Evaluations.Queries.GetEvaluationsList;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class EvaluationsController : BaseController
    {
        // GET: api/Evaluations/GetAll
        [HttpGet()]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<EvaluationsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetEvaluationsListQuery()));
        }

        // GET: api/Evaluations/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<EvaluationViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetEvaluationByIdQuery { Id = id }));
        }

        // POST: api/Evaluations/Create
        [HttpPost]
        [Authorize(Roles = Role.Student)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateEvaluationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Evaluations/Update
        [HttpPut()]
        [Authorize(Roles = Role.None)]
        public async Task<IActionResult> Update([FromBody] UpdateEvaluationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Evaluations/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.None)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEvaluationCommand { Id = id });

            return NoContent();
        }
    }
}
