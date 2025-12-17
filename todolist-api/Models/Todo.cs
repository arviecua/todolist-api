namespace todolist_api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
