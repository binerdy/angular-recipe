using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using Raven.Client.Documents.BulkInsert;
using ReferenceData.Model;

namespace ReferenceData.Host.Controllers
{
    [ApiController]
    [Route("reference-data-records")]
    public class ReferenceDataRecordController : ControllerBase
    {
        private readonly ILogger<ReferenceDataRecordController> logger;
        private readonly IDocumentStore documentStore;

        public ReferenceDataRecordController(
            ILogger<ReferenceDataRecordController> logger,
            IDocumentStore documentStore)
        {
            this.logger = logger;
            this.documentStore = documentStore;
        }

        [HttpGet()]
        public async Task<IEnumerable<ReferenceDataRecord>> GetReferenceDataRecords()
        {
            using (var session = documentStore.OpenAsyncSession())
            {
                return await session.LoadPrefix<ReferenceDataRecord>();
            };
        }

        [HttpPost()]
        public async IAsyncEnumerable<string> CreateReferenceDataRecords(ReferenceDataRecord[] referenceDataRecords)
        {
            using (var bulkInsertOperation = documentStore.BulkInsert(new BulkInsertOptions { SkipOverwriteIfUnchanged = true }))
            {
                foreach (var referenceDataRecord in referenceDataRecords)
                {
                    yield return await bulkInsertOperation.StoreAsync(referenceDataRecord);
                }
            }
        }
    }
}
