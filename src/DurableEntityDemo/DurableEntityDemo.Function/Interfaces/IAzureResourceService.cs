namespace DurableEntityDemo.Function;

public interface IAzureResourceService
{
    Task GetAzureResourceGroup(string? subscriptionId, string? resourceGroupName);
}
