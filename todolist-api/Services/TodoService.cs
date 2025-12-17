using Microsoft.EntityFrameworkCore;
using todolist_api.Context;
using todolist_api.Models;

namespace todolist_api.Services
{
    public class TodoService
    {

        #region VARIABLES
        private readonly MainDbContext mainDbContext;

        #endregion

        public TodoService(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public List<Todo> GetTodos()
        {
            return [.. mainDbContext.Todos.Select(t => new Todo
            {
                Id  = t.Id,
                Message = t.Message,
                IsCompleted = t.IsCompleted
            })];
        }

        public Todo GetTodo(int id)
        {
            try
            {
                return mainDbContext.Todos.Where(t => t.Id == id).Select(t => new Todo { Id = t.Id, Message = t.Message, IsCompleted = t.IsCompleted }).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Response AddTodo(Todo todo)
        {
            try
            {
                mainDbContext.Todos.Add(new Entities.Todos {Message = todo.Message, IsCompleted = todo.IsCompleted});
                mainDbContext.SaveChanges();



                return new Response
                {
                    Status = "success",
                    Payload = todo
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = "failed",
                    Message = ex.Message
                };
            }
        }

        public Response DeleteTodo(int id)
        {
            try
            {
                var t = mainDbContext.Todos.Where(x => x.Id == id).ExecuteDelete();


                return new Response
                {
                    Status = "success",
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = "failed",
                    Message = ex.Message
                };
            }
        }

        public Response UpdateTodo(Todo todo)
        {
            try
            {
                mainDbContext.Todos.Where(x => x.Id == todo.Id).ExecuteUpdate(setters => setters
                .SetProperty(x=> x.Message, todo.Message)
                .SetProperty(x=> x.IsCompleted, todo.IsCompleted)
                );


                return new Response
                {
                    Status = "success",

                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = "failed",
                    Message = ex.Message
                };
            }
        }
    }
}
