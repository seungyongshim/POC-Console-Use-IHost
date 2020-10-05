using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Worker : IHostedService
    {
        public Worker(ILogger<Worker> logger)
        {
            Logger = logger;
        }

        public ILogger<Worker> Logger { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Start");
            await Task.Yield();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stop");
            await Task.Yield();
        }
    }
}