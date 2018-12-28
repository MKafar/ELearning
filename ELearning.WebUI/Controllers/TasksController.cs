using System.Collections.Generic;
using System.Threading.Tasks;
using ELearning.Application.Tasks.Queries.GetTasksList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELearning.WebUI.Controllers
{
    public class TasksController : BaseController
    {
        // GET: api/Tasks/GetAll
        [HttpGet]
        public async Task<ActionResult<TasksListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetTasksListQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
