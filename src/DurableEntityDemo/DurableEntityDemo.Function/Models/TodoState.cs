namespace DurableEntityDemo.Function.Models;

// https://jsonplaceholder.typicode.com

public class TodoState
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }
}