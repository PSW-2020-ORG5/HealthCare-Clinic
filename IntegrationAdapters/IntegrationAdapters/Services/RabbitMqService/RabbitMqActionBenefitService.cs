using Health_Clinic_Integration.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using IntegrationAdapters.Repositories.DbContexts;

namespace Health_Clinic_Integration.Services.RabbitMqService
{
    public class RabbitMqActionBenefitService : BackgroundService
    {
        private IConnection connection;
        private IModel channel;
        private MyDbContext _context;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "psw2", durable: false, exclusive: false, autoDelete: false, arguments: null);

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string jsonMessage = Encoding.UTF8.GetString(body);
                ActionBenefit actionBenefit = JsonConvert.DeserializeObject<ActionBenefit>(jsonMessage);

                ConnectToDb();

                ActionBenefitService actionBenefitService = new ActionBenefitService(_context);
                actionBenefitService.Save(actionBenefit);
            };

            channel.BasicConsume(queue: "psw2", autoAck: true, consumer: consumer);
            return base.StartAsync(cancellationToken);
        }

        private void ConnectToDb()
        {
            var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkMySql()
                    .BuildServiceProvider();

            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseMySql("server=localhost;port=3306;database=newmydb;user=root;password=1337")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new MyDbContext(builder.Options);
            _context.Database.Migrate();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}