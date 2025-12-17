namespace todolist_api.Models
{
    public class Response
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public dynamic? Payload { get; set; }
    }
}
