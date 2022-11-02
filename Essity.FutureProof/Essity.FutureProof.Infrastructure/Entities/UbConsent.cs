using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public partial class UbConsent
    {
        public UbConsent()
        {
            UbConsumerConsents = new HashSet<UbConsumerConsent>();
            UbConsentType = new UbConsentType();
        }

        public int Id { get; set; }

        public int TypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Source { get; set; }

        [Required]
        [StringLength(150)]
        public string? Title { get; set; }

        [Required]
        [StringLength(250)]
        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual UbConsentType UbConsentType { get; set; }

        public virtual ICollection<UbConsumerConsent> UbConsumerConsents { get; set; }
    }
}