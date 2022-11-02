namespace Essity.FutureProof.Infrastructure.Entities
{
    public class UbProductTracking
    {
        public int Id { get; set; }

        public string? GpimProductCode { get; set; }

        public int SiteId { get; set; }

        public int HashCode { get; set; }
    }
}