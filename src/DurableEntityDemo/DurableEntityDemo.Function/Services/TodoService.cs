using System.Text.Json;
using DurableEntityDemo.Function.Models;

namespace DurableEntityDemo.Function.Services;

public class TodoService
{
    // Method called GetTodoAsync to request a new todo item from https://jsonplaceholder.typicode.com/todos/1 and return a TodoState object
    public async Task<TodoState?> GetTodoAsync(int entityKey)
    {
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