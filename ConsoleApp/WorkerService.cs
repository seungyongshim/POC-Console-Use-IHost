using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class WorkerService : IHostedService
    {
        public WorkerService(ILogger<WorkerService> logger, IHostApplicationLifetime appLifetime)
        {
            Logger = logger;
            AppLifetime = appLifetime;
        }

        public IHostApplicationLifetime AppLifetime { get; }
        public ILogger<WorkerService> Logger { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            AppLifetime.ApplicationStarted.Register(OnStarted);
            AppLifetime.ApplicationStopping.Register(OnStopping);
            AppLifetime.ApplicationStopped.Register(OnStopped);

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stop");
            await Task.Yield();
        }

        private void OnStarted()
        {
            Logger.LogInformation("OnStarted");
        }

        private void OnStopped()
        {
            Logger.LogInformation("OnStopped");
        }

        private void OnStopping()
        {
            Logger.LogInformation("OnStopping");
        }
    }
}