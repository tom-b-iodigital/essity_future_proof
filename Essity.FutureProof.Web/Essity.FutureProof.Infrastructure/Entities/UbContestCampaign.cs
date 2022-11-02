namespace Essity.FutureProof.Infrastructure.Entities
{
    /// <summary>
    /// represents the <see cref="UbContestCampaign"/>
    /// </summary>
    public class UbContestCampaign
    {
        public UbContestCampaign()
        {
            UbContestCodes = new List<UbContestCode>();
            UbContestSubmissions = new List<UbContestSubmission>();
        }

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the SiteId
        /// </summary>
        public int SiteId { get; set; }

        public string? AggregatedData { get; set; }

        public virtual ICollection<UbContestCode> UbContestCodes { get; set; }

        public virtual ICollection<UbContestSubmission> UbContestSubmissions { get; set; }
    }
}