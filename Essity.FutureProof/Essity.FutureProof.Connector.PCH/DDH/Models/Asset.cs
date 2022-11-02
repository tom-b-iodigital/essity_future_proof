namespace Essity.FutureProof.Connector.PCH.DDH.Models
{
    public class Asset
    {
        public string? Url { get; set; }

        public IEnumerable<Shottype>? ShotType { get; set; }

        public string? FormatId { get; set; }
    }
}