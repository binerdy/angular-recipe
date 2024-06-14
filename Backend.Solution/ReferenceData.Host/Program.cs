using Common;
using DataAccess;
using GenericHost = Microsoft.Extensions.Hosting.Host;

namespace ReferenceData.Host
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
                            .Configure<RavenSettings>(context.Configuration.GetSection("ReferenceData:RavenDb"))
                            .PostConfigure<RavenSettings>(ravenSettings =>
                            {
                                ravenSettings.IndexAssemblies = [
                                    typeof(RavenSettings).Assembly
                                ];
                            });
                })
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.AddSingleton<IDocumentStoreHolder, DocumentStoreHolder>();
                })
                .Build();

            await app.RunAsync();
        }
    }
}
