namespace Essity.FutureProof.Connector.PCH.DDH.Models
{
    public class DdhProduct
    {
        public string? ProductId { get; set; }

        public string? ProductBaseCode { get; set; }

        public string? Ean { get; set; }

        public string? PackCount { get; set; }

        public string? CountUsageCP { get; set; }

        public string? CountUsageCU { get; set; }

        public string? BrandName { get; set; }

        public string? ProductName { get; set; }

        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public string? Disclaimer { get; set; }

        public string? Layer { get; set; }

        public string? Color { get; set; }

        public bool? Pattern { get; set; }

        public bool? WithLotion { get; set; }

        public bool? Flushable { get; set; }

        public string? Moistness { get; set; }

        public bool? Scent { get; set; }

        public string? SheetFormat { get; set; }

        public string? RetailFormat { get; set; }

        public bool IsKeyProduct { get; set; }

        public IEnumerable<string>? Highlights { get; set; }

        public bool? Disposable { get; set; }

        public bool? DermaTested { get; set; }

        public bool? MachineResistable { get; set; }

        public bool? SoftStrong { get; set; }

        public bool? Wringable { get; set; }

        public bool? TadTechnology { get; set; }

        public bool? StrongAbsorbent { get; set; }

        public bool? Soft { get; set; }

        public bool? SoftPack { get; set; }

        public bool? PocketPack { get; set; }

        public bool? CubeFormat { get; set; }

        public bool? Biodegradable { get; set; }

        public bool? PefcCertified { get; set; }

        public bool? FscCertified { get; set; }

        public bool? OrganicCotton { get; set; }

        public bool? Recyclable { get; set; }

        public bool? CottonBuds { get; set; }

        public IEnumerable<string>? CrossReferences { get; set; }

        public IEnumerable<string>? ScentVariants { get; set; }

        public string? MdrAddressManufacturer { get; set; }

        public string? MdrAddressVisitor { get; set; }

        public string? MdrMedicalDeviceLabel { get; set; }

        public IEnumerable<IEnumerable<Asset>>? Assets { get; set; }
    }
}