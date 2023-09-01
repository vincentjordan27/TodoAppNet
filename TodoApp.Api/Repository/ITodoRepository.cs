using TodoApp.Api.Models.Domain;

namespace TodoApp.Api.Repository
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetMyTodo(Guid id);
        Task<Todo> InsertTodo(Todo todo);
        Task<Todo> GetTodoById(Guid id, Guid userId);
        Task<Todo> UpdateTodo(Guid id, Guid userId, Todo todo);
        Task<Todo> DeleteTodo(Guid id, Guid userId);
    }
}
