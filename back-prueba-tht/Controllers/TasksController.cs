using back_prueba_tht.Models;
using back_prueba_tht.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_prueba_tht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await _service.GetAllTasks());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var response = await _service.GetTaskById(id);

            if (response == null) 
            {
                return NotFound("La tarea no existe.");
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] Models.Task newTask)
        {
            var response = await _service.CreateTask(newTask);

            if (response == null)
            {
                return BadRequest("No se pudo crear el usuario.");
            }

            return Ok(response);
        }

        //[HttpPut]
        [HttpPost]
        [Route("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Models.Task updateTask)
        {
            var response = await _service.UpdateTask(id, updateTask);

            if (response == null)
            {
                return NotFound("La tarea no existe.");
            }

            return Ok(response);
        }

        //[HttpDelete]
        [HttpPost]
        [Route("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var response = await _service.DeleteTask(id);

            if (response == null)
            {
                return NotFound("La tarea no existe.");
            }

            return Ok(response);
        }
    }
}
