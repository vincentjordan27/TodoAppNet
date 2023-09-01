using TodoApp.Api.Models.Domain;

namespace TodoApp.Api.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetMyTodo(Guid id);
        Task<Todo> InsertTodo(Todo todo);
        Task<Todo> GetTodoById(Guid id, Guid userId);
    }
}
