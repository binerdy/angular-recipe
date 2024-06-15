using Common;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Exceptions.Database;
using Raven.Client.Exceptions;
using Raven.Client.ServerWide.Operations;
using Raven.Client.ServerWide;
using Sparrow;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    /// <summary>
    /// Configures a document store for a specific database. Creates the database if it doesn't exist.
    /// </summary>
    /// <param name="ravenSettingsOption"></param>
    /// <param name="logger"></param>
    /// <seealso href="https://ravendb.net/docs/article-page/6.0/csharp/client-api/creating-document-store"/>
    public static class DocumentStoreFactory
    {
        public static IDocumentStore CreateInstance(RavenSettings ravenSettings)
        {
            var documentStore = new DocumentStore()
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

            documentStore.Initialize();
            EnsureDatabaseExists(documentStore);

            return documentStore;
        }

        /// <seealso href="https://ravendb.net/docs/article-page/4.0/csharp/client-api/operations/server-wide/create-database"/>
        private static void EnsureDatabaseExists(DocumentStore documentStore)
        {
            try
            {
                documentStore.Maintenance.ForDatabase(documentStore.Database).Send(new GetStatisticsOperation());
            }
            catch (DatabaseDoesNotExistException)
            {
                try
                {
                    documentStore.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(documentStore.Database)));
                }
                catch (ConcurrencyException)
                {
                    // The database was already created before calling CreateDatabaseOperation
                }
            }
        }
    }
}
