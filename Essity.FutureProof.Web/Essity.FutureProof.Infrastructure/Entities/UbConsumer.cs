using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public partial class UbConsumer
    {
        public UbConsumer()
        {
            UbConsumerConsents = new HashSet<UbConsumerConsent>();
            UbContacts = new List<UbContact>();
            UbContestSubmissions = new List<UbContestSubmission>();
            UbReviews = new List<UbReview>();
            UbEqualitySurveys = new List<UbEqualitySurvey>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string? FirstName { get; set; }

        [StringLength(250)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(250)]
        public string? Email { get; set; }

        public string? Extra { get; set; }

        [StringLength(300)]
        public string? SourceTags { get; set; }

        [StringLength(500)]
        public string? UserAgent { get; set; }

        [StringLength(300)]
        public string? PageUrl { get; set; }

        [StringLength(300)]
        public string? Referer { get; set; }

        public DateTime DateCreated { get; set; }

        public int? SiteId { get; set; }

        public virtual ICollection<UbConsumerConsent> UbConsumerConsents { get; set; }

        public virtual ICollection<UbContact> UbContacts { get; set; }

        public virtual ICollection<UbContestSubmission> UbContestSubmissions { get; set; }

        public virtual ICollection<UbReview> UbReviews { get; set; }

        public virtual ICollection<UbEqualitySurvey> UbEqualitySurveys { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}