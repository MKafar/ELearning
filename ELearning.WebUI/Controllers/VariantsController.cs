using System.Net;
using System.Threading.Tasks;
using ELearning.Application.Variants.Commands.CreateVariant;
using ELearning.Application.Variants.Commands.DeleteVariant;
using ELearning.Application.Variants.Commands.UpdateVariant;
using ELearning.Application.Variants.Queries.GetVariantById;
using ELearning.Application.Variants.Queries.GetVariantsList;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class VariantsController : BaseController
    {
        // GET: api/Variants/GetAll
        [HttpGet]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<VariantsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetVariantsListQuery()));
        }

        // GET: api/Variants/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<VariantViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetVariantByIdQuery { Id = id }));
        }

        // POST: api/Variants/Create
        [HttpPost]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateVariantCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Variants/Update/
        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateVariantCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Variants/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVariantCommand { Id = id });

            return NoContent();
        }
    }
}
