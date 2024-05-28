using System.Net;
using DurableEntityDemo.Function.Entities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;
using Microsoft.DurableTask.Entities;
using Microsoft.Extensions.Logging;

namespace DurableEntityDemo.Function;

public class HttpTrigger
{
    private readonly ILogger _logger;

    public HttpTrigger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<HttpTrigger>();
    }
    
    // [Function("DeleteCounter")]
    // public static async Task<HttpResponseData> DeleteCounter(
    //     [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "Counter/{entityKey}")] HttpRequestData req,
    //     [DurableClient] DurableTaskClient client, string entityKey)
    // {
    //     var entityId = new EntityInstanceId("Counter", entityKey);
    //     await client.Entities.SignalEntityAsync(entityId, "Delete");
    //     return req.CreateResponse(HttpStatusCode.Accepted);
    // }

    [Function("CreateTodoEntity")]
    public async Task<HttpResponseData> CreateTodoEntity([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Todo/{entityKey}")] HttpRequestData req,
        [DurableClient] DurableTaskClient client, string entityKey)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        // Print the entity key
        _logger.LogInformation("Entity key: {EntityKey}", entityKey);
        
        var entityId = new EntityInstanceId(nameof(TodoEntity), entityKey);
        await client.Entities.SignalEntityAsync(entityId, "Initialize");

        return req.CreateResponse(HttpStatusCode.Accepted);
    }
}