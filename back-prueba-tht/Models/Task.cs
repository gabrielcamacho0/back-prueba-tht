using System.ComponentModel.DataAnnotations;

namespace back_prueba_tht.Models
{
    public class Task
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string? description { get; set; } = null;
        [DataType("TIMESTAMP WITH TIME ZONE")]
        public DateTime due_date { get; set; }
        public string status { get; set; }
    }
}
