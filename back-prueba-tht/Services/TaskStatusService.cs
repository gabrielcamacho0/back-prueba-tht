using back_prueba_tht.Models;
using Microsoft.EntityFrameworkCore;

namespace back_prueba_tht.Services
{
    public class TaskStatusService
    {
        private readonly ApplicationDbContext _context;

        public TaskStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.TaskStatus>> GetAllTasksStatus()
        {
            return await _context.taskStatus.ToListAsync();
        }
    }
}
