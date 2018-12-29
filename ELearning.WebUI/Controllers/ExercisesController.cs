using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Exercises.Commands.CreateExercise;
using ELearning.Application.Exercises.Commands.DeleteExercise;
using ELearning.Application.Exercises.Commands.UpdateExercise;
using ELearning.Application.Exercises.Queries.GetExerciseById;
using ELearning.Application.Exercises.Queries.GetExercisesList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELearning.WebUI.Controllers
{
    public class ExercisesController : BaseController
    {
        // GET: api/tasks/GetAll
        [HttpGet]
        public async Task<ActionResult<ExercisesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetExercisesListQuery()));
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetExerciseByIdQuery { Id = id }));
        }

        // POST api/tasks
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateExerciseCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateExerciseCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteExerciseCommand { Id = id });

            return NoContent();
        }
    }
}
