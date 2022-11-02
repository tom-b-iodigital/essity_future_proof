using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    /// <summary>
    /// Represents the <see cref="UbContestCode"/>
    /// </summary>
    public class UbContestCode
    {
        public UbContestCode()
        {
            UbContestCampaign = new UbContestCampaign();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ActionCode
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string? ActionCode { get; set; }

        /// <summary>
        /// Gets or sets the DateCreated
        /// </summary>
        public DateTime DateCreated { get; set; }

        public int CampaignId { get; set; }

        public virtual UbContestCampaign UbContestCampaign { get; set; }
    }
}