using DurableEntityDemo.Function;
using DurableEntityDemo.Function.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddSingleton<ITodoService, TodoService>();
    })
    .Build();

host.Run();