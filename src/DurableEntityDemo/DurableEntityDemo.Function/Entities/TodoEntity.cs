using DurableEntityDemo.Function.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask.Entities;
using Microsoft.Extensions.Logging;

namespace DurableEntityDemo.Function.Entities;

public class TodoEntity : TaskEntity<TodoState>
{
    private readonly ILogger _logger;

    public TodoEntity(ILogger<TodoEntity> logger)
    {
        _logger = logger;
        _logger.LogInformation("Log 1");
    }
    
    public Task Initialize()
    {
        // Create sample TodoState and save to state
        State = new TodoState
        {
            UserId = 1,
            Id = 1,
            Title = "delectus aut autem",
            Completed = false
        };

        // Print the state to the log
        _logger.LogInformation("Log 2");
        Console.WriteLine($"Initialized TodoEntity with state: {State.Id}");
        
        return Task.CompletedTask;
    }
    
    [Function(nameof(TodoEntity))]
    public static Task RunEntityStaticAsync([EntityTrigger] TaskEntityDispatcher dispatcher)
        => dispatcher.DispatchAsync<TodoEntity>();
}