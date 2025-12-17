using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todolist_api.Context;
using todolist_api.Models;
using todolist_api.Services;

namespace todolist_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase    
    {
        public readonly TodoService todoService;
        public TodoController(MainDbContext mainDbContext) => todoService = new(mainDbContext);

        [HttpGet("GetTodos")]
        public IActionResult GetTodos() => Ok(todoService.GetTodos());

        [HttpGet("GetTodo/{id}")]
        public IActionResult GetTodo(int id) => Ok(todoService.GetTodo(id));

        [HttpPost("AddTodo")]
        public IActionResult AddTodo(Todo todo) => Ok(todoService.AddTodo(todo));

        [HttpPost("DeleteTodo/{id}")]
        public IActionResult DeleteTodo(int id) => Ok(todoService.DeleteTodo(id));

        [HttpPost("UpdateTodo")]
        public IActionResult UpdateTodo(Todo todo) => Ok(todoService.UpdateTodo(todo));
    }
}
