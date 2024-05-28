using DurableEntityDemo.Function.Models;

namespace DurableEntityDemo.Function;

public interface ITodoService
{
    Task<TodoState?> GetTodoAsync(string entityKey);
}