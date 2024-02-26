using Ktt.ScopeTest.Services.Context;

namespace Ktt.ScopeTest.Services;

public sealed class MyBackgroundService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<MyBackgroundService> logger) : BackgroundService
{
    private const string _className = nameof(MyBackgroundService);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation($"{_className} is running.");

        while (true)
        {
            await DoWorkAsync(stoppingToken);
            await Task.Delay(10000, stoppingToken);
        }
    }

    private async Task DoWorkAsync(CancellationToken stoppingToken)
    {
        await Task.CompletedTask;

        logger.LogInformation($"{_className} is working.");

        foreach (var item in new string[] { "localhost", "test" })
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var labelContextProvider = scope.ServiceProvider.GetRequiredService<LabelContextProvider>();
                labelContextProvider.Context = new LabelContext(item);

                var myService = scope.ServiceProvider.GetRequiredService<MyService>();
                var msg = myService.DoSomethingThatNeedsALabel();
                logger.LogInformation(msg);
            }
        }
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation($"{_className} is stopping.");
        await base.StopAsync(stoppingToken);
    }
}
