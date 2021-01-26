using Health_Clinic_Integration.Services.RabbitMqService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActionBenefitMicro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task rabbitMQTask = new Task(() => CreateHostBuilderForMessages(args).Build().Run());
            rabbitMQTask.Start();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
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
