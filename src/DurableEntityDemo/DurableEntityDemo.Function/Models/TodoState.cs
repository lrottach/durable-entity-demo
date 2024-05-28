using System.Text.Json.Serialization;

namespace DurableEntityDemo.Function.Models;

// https://jsonplaceholder.typicode.com

public class TodoState
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
}