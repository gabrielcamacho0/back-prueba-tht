using back_prueba_tht.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace back_prueba_tht.Services
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Task>> GetAllTasks()
        {
            return await _context.task.ToListAsync();
        }

        public async Task<Models.Task?> GetTaskById(int id)
        {
            return await _context.task.FindAsync(id);
        }

        public async Task<Models.Task> CreateTask(Models.Task newTask)
        {
            newTask.due_date = new DateTime(newTask.due_date.Year, newTask.due_date.Month, newTask.due_date.Day, newTask.due_date.Hour, newTask.due_date.Minute, newTask.due_date.Second, DateTimeKind.Utc);
            await _context.task.AddAsync(newTask);
            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task<Models.Task?> UpdateTask(int id, Models.Task updateTask)
        {
            var updated = await _context.task.FindAsync(id);

            if (updated == null) 
            {
                return null;
            }

            updated.title = updateTask.title;
            updated.description = updateTask.description;
            updated.status = updateTask.status;
            updated.due_date = new DateTime(updateTask.due_date.Year, updateTask.due_date.Month, updateTask.due_date.Day, updateTask.due_date.Hour, updateTask.due_date.Minute, updateTask.due_date.Second, DateTimeKind.Utc);
            await _context.SaveChangesAsync();

            return updated;
        }

        public async Task<Models.Task?> DeleteTask(int id)
        {
            var deleted = await _context.task.FindAsync(id);

            if (deleted == null)
            {
                return null;
            }

            _context.task.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
    }
}
