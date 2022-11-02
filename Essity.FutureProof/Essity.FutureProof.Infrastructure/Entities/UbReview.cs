namespace Essity.FutureProof.Infrastructure.Entities
{
    public class UbReview
    {
        public UbReview()
        {
            UbConsumer = new UbConsumer();
        }

        public int ReviewId { get; set; }

        public string? Title { get; set; }

        public string? ReviewDescription { get; set; }

        public double ReviewRating { get; set; }

        public DateTime DateCreated { get; set; }

        public int ConsumerId { get; set; }

        public UbConsumer UbConsumer { get; set; }

        public int ProductId { get; set; }

        public bool Visible { get; set; } = true;

        public string? ProductUrl { get; set; }

        public DateTime? BrandReplyDate { get; set; }

        public string? BrandReply { get; set; }
    }
}