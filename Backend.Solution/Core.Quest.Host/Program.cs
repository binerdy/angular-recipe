
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Shared.DataAccess;
using GenericHost = Microsoft.Extensions.Hosting.Host;

namespace Quest.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = GenericHost
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .ConfigureServices((context, services) =>
                        {
                            services.AddControllers();
                            services.AddEndpointsApiExplorer();
                            services.AddSwaggerGen();
                        })
                        .Configure((hostContext, app) =>
                        {
                            if (hostContext.HostingEnvironment.IsDevelopment())
                            {
                                app.UseSwagger();
                                app.UseSwaggerUI();
                            }

                            app.UseRouting();
                            app.UseHttpsRedirection();
                            app.UseAuthorization();

                            app.UseEndpoints(endpoints =>
                            {
                                endpoints.MapControllers();
                            });
                        });
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<RavenSettings>(context.Configuration.GetSection("RavenDb"))
                            .Configure<RavenSettings>(context.Configuration.GetSection("Quest:RavenDb"))
                            .PostConfigure<RavenSettings>(ravenSettings =>
                            {
                                ravenSettings.IndexAssemblies = [
                                    typeof(RavenSettings).Assembly
                                ];
                            });
                })
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.AddSingleton<IDocumentStore>(serviceCollection =>
                    {
                        var ravenSettings = serviceCollection.GetRequiredService<IOptions<RavenSettings>>();
                        return DocumentStoreFactory.CreateInstance(ravenSettings.Value);
                    });
                })
                .Build();

            await app.RunAsync();
        }
    }
}
