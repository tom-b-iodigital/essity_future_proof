using System.ComponentModel.DataAnnotations;

namespace Essity.FutureProof.Infrastructure.Entities
{
    public partial class UbContact
    {
        public UbContact()
        {
            UbConsumer = new UbConsumer();
        }

        public int Id { get; set; }

        [Required]
        public string? Message { get; set; }

        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the ConsumerId
        /// </summary>
        public int ConsumerId { get; set; }

        public string? ExtraInfo { get; set; }

        /// <summary>
        /// Gets or sets the UbConsumer
        /// </summary>
        public virtual UbConsumer UbConsumer { get; set; }
    }
}