using Essity.FutureProof.Infrastructure.Enums;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public class UbDataCleanupLog
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public DataCleanupType Type { get; set; }

        /// <summary>
        /// Gets or sets SiteId
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets NrOfDeletedConsumers
        /// </summary>
        public int NrOfDeletedConsumers { get; set; }

        /// <summary>
        /// Gets or sets the ExtraInfo property.
        /// Optional, used to store JSON serialized objects containing more details
        /// </summary>
        public string? ExtraInfo { get; set; }

        /// <summary>
        /// Gets or sets the StartedAt property.
        /// Indicates the moment the cleanup job was initiated.
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// Gets or sets the Completed property.
        /// Indicates the moment the cleanup job was completed.
        /// </summary>
        public DateTime? CompletedAt { get; set; }
    }
}