using DurableEntityDemo.Function.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Entities;
using Microsoft.Extensions.Logging;

namespace DurableEntityDemo.Function.Entities;

public class TodoEntity : TaskEntity<TodoState>
{
    private readonly ILogger _logger;
    private readonly ITodoService _todoService;

    public TodoEntity(ILogger<TodoEntity> logger, ITodoService todoService)
    {
        _logger = logger;
        _todoService = todoService;
    }
    
    public async Task<Task> InitializeAsync(string entityKey)
    {
        // Get the todo item from the service
        State = await _todoService.GetTodoAsync(entityKey) ?? throw new InvalidOperationException();
        
        // Print the state to the log
        _logger.LogInformation("Log 2");
        Console.WriteLine($"Initialized TodoEntity with state: {State.Id}");
        
        return Task.CompletedTask;
    }
    
    [Function(nameof(TodoEntity))]
    public static Task RunEntityStaticAsync([EntityTrigger] TaskEntityDispatcher dispatcher)
        => dispatcher.DispatchAsync<TodoEntity>();
}