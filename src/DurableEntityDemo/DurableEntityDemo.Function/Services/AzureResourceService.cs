using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.Extensions.Logging;

namespace DurableEntityDemo.Function.Services;

public class AzureResourceService : IAzureResourceService
{
    private DefaultAzureCredential Credential { get; } = new();
    private readonly ILogger _logger;

    public AzureResourceService(ILogger<AzureResourceService> logger)
    {
        _logger = logger;
    }
    
    public async Task GetAzureResourceGroup(string? subscriptionId, string? resourceGroupName)
    {
        _logger.LogInformation($"[] Getting Resource Group '{resourceGroupName}' in Subscription '{subscriptionId}'");
        var client = new ArmClient(Credential);
        var resourceGroupIdentifier = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
        var resourceGroupResource = client.GetResourceGroupResource(resourceGroupIdentifier);
        var resourceGroup = await resourceGroupResource.GetAsync();
        Console.WriteLine($"[] Resource Group '{resourceGroup.Value.Data.Name}' found");
    }
}