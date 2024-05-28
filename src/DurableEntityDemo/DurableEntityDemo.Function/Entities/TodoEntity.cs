using DurableEntityDemo.Function.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Entities;
using Microsoft.Extensions.Logging;

namespace DurableEntityDemo.Function.Entities;

public class TodoEntity : TaskEntity<TodoState>
{
    private readonly ILogger<TodoEntity> _logger;

    public TodoEntity(ILogger<TodoEntity> logger)
    {
        _logger = logger;
    }
    
    public Task Initialize(int userId, int id, string title, bool completed)
    {
        State = new TodoState
        {
            UserId = userId,
            Id = id,
            Title = title,
            Completed = completed
        };
        return Task.CompletedTask;
    }
    
    [Function(nameof(TodoEntity))]
    public static Task Run([EntityTrigger] TaskEntityDispatcher dispatcher)
        => dispatcher.DispatchAsync<TodoEntity>();
}