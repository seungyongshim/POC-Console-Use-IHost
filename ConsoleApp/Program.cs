using FluentAssertions.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((h, s) =>
                {
                    s.Configure<HostOptions>(o =>
                    {
                        o.ShutdownTimeout = 20.Seconds();
                    });
                    s.AddHostedService<WorkerService>();
                });

        private static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }
    }
}