using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Exercises.Commands.CreateExercise;
using ELearning.Application.Exercises.Commands.DeleteExercise;
using ELearning.Application.Exercises.Commands.UpdateExercise;
using ELearning.Application.Exercises.Queries.GetExerciseById;
using ELearning.Application.Exercises.Queries.GetExercisesList;
using ELearning.Application.Exercises.Queries.GetExerciseVariantsListById;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class ExercisesController : BaseController
    {
        // GET: api/Exercises/GetAll
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ExercisesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetExercisesListQuery()));
        }

        // GET api/Exercises/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ExerciseViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetExerciseByIdQuery { Id = id }));
        }

        // GET api/Exercises/GetAllVariantsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ExerciseVariantsListViewModel>> GetAllVariantsById(int id)
        {
            return Ok(await Mediator.Send(new GetExerciseVariantsListByIdQuery { Id = id }));
        }

        // POST api/Exercises/Create
        [HttpPost]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateExerciseCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT api/Exercises/Update
        [HttpPut]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateExerciseCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/Exercises/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteExerciseCommand { Id = id });

            return NoContent();
        }
    }
}
