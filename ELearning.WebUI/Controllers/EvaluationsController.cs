using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Evaluations.Commands.CreateEvaluation;
using ELearning.Application.Evaluations.Commands.DeleteEvaluation;
using ELearning.Application.Evaluations.Commands.UpdateEvaluation;
using ELearning.Application.Evaluations.Models;
using ELearning.Application.Evaluations.Queries.GetEvaluationById;
using ELearning.Application.Evaluations.Queries.GetEvaluationsListByAssignmentId;
using ELearning.Application.Evaluations.Queries.GetEvaluationsListBySectionId;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class EvaluationsController : BaseController
    {
        // GET: api/Evaluations/GetAllByAssignmentId
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationsListViewModel>> GetAllByAssignmentId(int id)
        {
            return Ok(await Mediator.Send(new GetEvaluationsListByAssignmentIdQuery { Id = id }));
        }

        // GET: api/Evaluations/GetAllBySectionId
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationsListViewModel>> GetAllBySectionId(int id)
        {
            return Ok(await Mediator.Send(new GetEvaluationsListBySectionIdQuery { Id = id }));
        }

        // GET: api/Evaluations/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetEvaluationByIdQuery { Id = id }));
        }

        // POST: api/Evaluations/Create
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateEvaluationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Evaluations/Update
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] UpdateEvaluationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Evaluations/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEvaluationCommand { Id = id });

            return NoContent();
        }
    }
}
