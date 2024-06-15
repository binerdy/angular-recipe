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
            IDocumentStore documentStore)
        {
            this.logger = logger;
            this.documentStore = documentStore;
        }

        [HttpGet(Name = "record")]
        public IEnumerable<ReferenceDataRecord> GetReferenceDataRecord()
        {
            using (var session = this.documentStore.OpenSession())
            {
            }

            return [];
        }
    }
}
