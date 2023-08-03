using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.API.Data
{
    public class Todo : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Urgent = 10
    }
    public abstract class BaseModel
    {
        public bool IsActive { get; set; }
        public DateTime CreatedAtDateTime { get; set; } = DateTime.Now;
        public DateTime UpdatedAtDateTime { get; set; } = DateTime.Now;
    }
}
