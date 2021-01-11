using Grpc.Core;
using IntegrationAdapters.Protos;
using IntegrationAdapters.Dtos;
using IntegrationAdapters.Repositories.DbContexts;
using IntegrationAdapters.Services.GrpcService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace IntegrationAdapters
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MyDbContext>(options =>
                     options.UseMySql(
                       CreateConnectionStringFromEnvironment(),
                       mySqlOptions =>
                           mySqlOptions.EnableRetryOnFailure(
                              maxRetryCount: 5,
                              maxRetryDelay: TimeSpan.FromSeconds(10),
                              errorNumbersToAdd: null)
            ).UseLazyLoadingProxies());

            services.AddCors(options =>
            {
                options.AddPolicy("Policy",
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });

            });

            ConfigurationDto instance = ConfigurationDto.GetInstance();
            instance.myDbConnectionString = Configuration.GetConnectionString(CreateConnectionStringFromEnvironment());
        }

        private Server server;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Programatically triggering migrations
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
               scope.ServiceProvider.GetService<MyDbContext>().Database.Migrate();
            }

            // grpc
            string grpc_host = Environment.GetEnvironmentVariable("GRPC_HOST") ?? "localhost";
            string grpc_port = Environment.GetEnvironmentVariable("GRPC_PORT") ?? "4111";
            server = new Server
            {
                Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
                Ports = { new ServerPort(grpc_host, Int32.Parse(grpc_port), ServerCredentials.Insecure) }
            };

            server.Start();
        }
        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }
        }

        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newmydb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "1337";
            string sslMode = Environment.GetEnvironmentVariable("DATABASE_SSL_MODE") ?? "None";
            return $"server={server};port={port};database={database};user={user};password={password};";
        }
    }
}
