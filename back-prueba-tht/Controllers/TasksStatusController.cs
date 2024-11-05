using back_prueba_tht.Models;
using back_prueba_tht.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_prueba_tht.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksStatusController : ControllerBase
    {
        private readonly TaskStatusService _service;

        public TasksStatusController(TaskStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksStatus()
        {
            return Ok(await _service.GetAllTasksStatus());
        }
    }
}
