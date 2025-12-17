using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todolist_api.Entities
{
    [Table("Todo")]
    public class Todos
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
