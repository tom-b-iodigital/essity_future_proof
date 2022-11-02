using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    /// <summary>
    /// Represents an <see cref="UbEqualitySurvey" />
    /// </summary>
    public class UbEqualitySurvey
    {
        public UbEqualitySurvey()
        {
            Consumer = new UbConsumer();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        public string? HouseholdScores { get; set; }

        /// <summary>
        /// Gets or sets the Gender
        /// </summary>
        [MaxLength(1)]
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the HouseholdAverageScore
        /// </summary>
        public decimal HouseholdAverageScore { get; set; }

        /// <summary>
        /// Gets or sets the StatementParentsInfluenceFuture
        /// </summary>
        public int StatementParentsInfluenceFuture { get; set; }

        /// <summary>
        /// Gets or sets the StatementHouseholdSharedResponsibility
        /// </summary>
        public int StatementHouseholdSharedResponsibility { get; set; }

        /// <summary>
        /// Gets or sets the DateCreated
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the SiteId
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the ConsumerId
        /// </summary>
        public int? ConsumerId { get; set; }

        /// <summary>
        /// Gets or sets the UbConsumer
        /// </summary>
        public virtual UbConsumer Consumer { get; set; }
    }
}