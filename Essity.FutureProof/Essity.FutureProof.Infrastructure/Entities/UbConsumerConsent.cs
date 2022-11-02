using System.ComponentModel.DataAnnotations.Schema;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public partial class UbConsumerConsent
    {
        public UbConsumerConsent()
        {
            UbConsent = new UbConsent();
            UbConsumer = new UbConsumer();
        }

        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsumerId { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ConsentId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool OptInConfirmed { get; set; } = false;

        public bool IsUnsubscribed { get; set; } = false;

        public string? ConsentVersion { get; set; }

        public int? CMSPropertyDataId { get; set; }

        public int? SiteId { get; set; }

        public virtual UbConsent UbConsent { get; set; }

        public virtual UbConsumer UbConsumer { get; set; }
    }
}