namespace Essity.FutureProof.Infrastructure.Entities
{
    public class UbWebLike
    {
        public int Id { get; set; }

        public string? CookieName { get; set; }

        public int NodeId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsLike { get; set; }
    }
}