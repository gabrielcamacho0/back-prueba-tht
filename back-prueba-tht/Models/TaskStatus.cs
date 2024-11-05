using System.ComponentModel.DataAnnotations.Schema;

namespace back_prueba_tht.Models
{
    [Table("task_status")]
    public class TaskStatus
    {
        public int id { get; set; }
        public string name {  get; set; }
    }
}
