using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TasksAPI.Models;
using TasksAPI.Services;

namespace TasksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService tasksS;

        public TasksController(ITasksService service) =>
            tasksS = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await tasksS.GetTareas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var tarea = await tasksS.GetByIdAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tareas tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await tasksS.CreateAsync(tarea);
            return Ok(tarea.TareaId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Tareas tarea)
        {
            var tare = await tasksS.GetByIdAsync(id);
            if (tare == null)
            {
                return NotFound();
            }

            await tasksS.UpdateAsync(id, tarea);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tarea = await tasksS.GetByIdAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            await tasksS.DeleteAsync(id);

            return NoContent();
        }
    }
}
