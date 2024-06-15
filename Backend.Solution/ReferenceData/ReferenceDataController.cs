using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using ReferenceData.Model;

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
        public async Task<IEnumerable<ReferenceDataRecord>> GetReferenceDataRecord()
        {
            using (var session = this.documentStore.OpenAsyncSession())
            {
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "flight",
                    DisplayName = "Flight",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "invisibility",
                    DisplayName = "Invisibility",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "super-strength",
                    DisplayName = "Super Strength",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "telepathy",
                    DisplayName = "Telepathy",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "time-travel",
                    DisplayName = "Time Travel",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });



                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "kryptonite",
                    DisplayName = "Kryptonite",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "magic",
                    DisplayName = "Magic",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "sound-frequency",
                    DisplayName = "Sound Frequency",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "water",
                    DisplayName = "Water",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });
                await session.StoreNewRevision(new ReferenceDataRecord
                {
                    Key = "fire",
                    DisplayName = "Fire Weakness",
                    ReferenceDataType = ReferenceDataType.Power,
                    ValidFrom = new DateOnly(1900, 1, 1),
                    ValidTo = new DateOnly(2100, 1, 1),
                });

                await session.SaveChangesAsync();

                return await session.LoadPrefix<ReferenceDataRecord>();
            };
        }
    }
}
