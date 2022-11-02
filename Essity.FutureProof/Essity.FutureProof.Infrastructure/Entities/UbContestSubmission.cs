using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    /// <summary>
    /// Represents an <see cref="UbContestSubmission" />
    /// </summary>
    public class UbContestSubmission
    {
        public UbContestSubmission()
        {
            UbConsumer = new UbConsumer();
            UbContestCampaign = new UbContestCampaign();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        public string? ActionCode { get; set; }

        /// <summary>
        /// Gets or sets the ExtraQuestion
        /// </summary>
        public string? Extra { get; set; }

        /// <summary>
        /// Gets or sets the DateCreated
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the ConsumerId
        /// </summary>
        public int ConsumerId { get; set; }

        /// <summary>
        /// Gets or sets the UbConsumer
        /// </summary>
        public virtual UbConsumer UbConsumer { get; set; }

        /// <summary>
        /// Gets or sets the CampaignId
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the UbConstestCampaign
        /// </summary>
        public virtual UbContestCampaign UbContestCampaign { get; set; }
    }
}