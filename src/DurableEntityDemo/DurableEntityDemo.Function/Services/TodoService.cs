using System.Text.Json;
using DurableEntityDemo.Function.Models;
using Microsoft.Extensions.Logging;

namespace DurableEntityDemo.Function.Services;

public class TodoService : ITodoService
{
    private readonly ILogger _logger;

    public TodoService(ILogger<TodoService> logger)
    {
        _logger = logger;
    }
    
    // Method called GetTodoAsync to request a new todo item from https://jsonplaceholder.typicode.com/todos/1 and return a TodoState object
    public async Task<TodoState?> GetTodoAsync(string entityKey)
    {
        _logger.LogInformation("Start requesting a new todo for entity key: {entityKey}", entityKey);
        
        // Create a new HttpClient
        using var client = new HttpClient();
        
        // Make a GET request to https://jsonplaceholder.typicode.com/todos/${entityKey}
        var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{entityKey}");
        
        // If the response is successful, read the content and return a new TodoState object
        if (!response.IsSuccessStatusCode) return null;
        var content = await response.Content.ReadAsStringAsync();
        var todo = JsonSerializer.Deserialize<TodoState>(content);
        return todo;
    }
}