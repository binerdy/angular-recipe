using Common;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Sparrow;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettingsOption)
        {
            var ravenSettings = ravenSettingsOption.Value;
            this.DocumentStore = new DocumentStore()
            {
                Urls = ravenSettings.Urls,
                Conventions =
                {
                    MaxNumberOfRequestsPerSession = 10,
                    UseOptimisticConcurrency = true,
                    MaxHttpCacheSize = new Size(ravenSettings.MaxHttpCacheSizeInMb, SizeUnit.Megabytes),
                    RequestTimeout = ravenSettings.RequestTimeout,
                },
                Database = ravenSettings.DatabaseName,
                Certificate = string.IsNullOrEmpty(ravenSettings.Pfx)
                    ? null
                    : new X509Certificate2(
                        Convert.FromBase64String(ravenSettings.Pfx),
                        new NetworkCredential(null, ravenSettings.Password).SecurePassword)
            };

            this.DocumentStore.Initialize();
        }

        public IDocumentStore DocumentStore { get; }
    }
}
