using System.Threading.Tasks;
using ELearning.Application.Roles.Queries.GetRoleById;
using ELearning.Application.Roles.Queries.GetRolesList;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.WebUI.Controllers
{
    [ApiController]
    public class RolesController : BaseController
    {
        // GET: api/Roles/GetAll
        [HttpGet]
        public async Task<ActionResult<RolesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetRolesListQuery()));
        }

        // GET: api/Roles/GetById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetRoleByIdQuery { Id = id }));
        }
    }
}
