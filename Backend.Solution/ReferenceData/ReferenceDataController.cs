using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;

namespace ReferenceData.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
        private readonly ILogger<ReferenceDataController> logger;
        private readonly IDocumentStore documentStore;

        public ReferenceDataController(
            ILogger<ReferenceDataController> logger,
            IDocumentStoreHolder documentStoreHolder)
        {
            this.logger = logger;
            this.documentStore = documentStoreHolder.DocumentStore;
        }

        [HttpGet(Name = "record")]
        public IEnumerable<ReferenceDataRecord> GetReferenceDataRecord()
        {
            return [];
        }
    }
}
