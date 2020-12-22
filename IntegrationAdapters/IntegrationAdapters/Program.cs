using System;
using System.Threading.Tasks;
using Health_Clinic_Integration.Services.RabbitMqService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace IntegrationAdapters
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Task rabbitMQTask = new Task(() => CreateHostBuilderForMessages(args).Build().Run());
            rabbitMQTask.Start();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<ClientScheduledService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IHostBuilder CreateHostBuilderForMessages(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<RabbitMqActionBenefitService>();
            });
    }
}
