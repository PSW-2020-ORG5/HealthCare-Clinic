using Grpc.Core;
using IntegrationAdapters.Protos;
using IntegrationAdapters.Repositories.DbContexts;
using IntegrationAdapters.Services.GrpcService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            options.UseMySql(ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString")).UseLazyLoadingProxies());

            services.AddCors(options =>
            {
                options.AddPolicy("Policy",
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });

            });

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
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // grpc
            server = new Server
            {
                Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
                Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
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
    }
}
