using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public partial class UbConsentType
    {
        public UbConsentType()
        {
            UbConsents = new HashSet<UbConsent>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Code { get; set; }

        [Required]
        [StringLength(255)]
        public string? Description { get; set; }

        public virtual ICollection<UbConsent> UbConsents { get; set; }
    }
}