using DurableEntityDemo.Function.Models;

namespace DurableEntityDemo.Function;

public interface ITodoService
{
    Task<TodoState?> GetTodoAsync(int entityKey);
}