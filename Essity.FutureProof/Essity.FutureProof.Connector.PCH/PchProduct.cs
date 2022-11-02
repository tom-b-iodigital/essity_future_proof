using Essity.FutureProof.Domain.Enums;
using Essity.FutureProof.Domain.Interfaces;
using Essity.FutureProof.Domain.Models;
using System.Text;

namespace Essity.FutureProof.Connector.PCH
{
    public class PchProduct : IDomainProduct
    {
        public PchProduct()
        {
            Children = new List<IDomainProduct>();
        }

        public string? CountUsageCU { get; set; }

        public string? CountUsageCP { get; set; }

        public string? PackCount { get; set; }

        public ProductSimpleAttribute CottonBuds { get; set; }

        public ProductSimpleAttribute PocketPack { get; set; }

        public ProductSimpleAttribute CubeFormat { get; set; }

        public ProductSimpleAttribute SoftPack { get; set; }

        public ProductSimpleAttribute Disposable { get; set; }

        public ProductSimpleAttribute DermaTested { get; set; }

        public ProductSimpleAttribute MachineResistable { get; set; }

        public ProductSimpleAttribute SoftStrong { get; set; }

        public ProductSimpleAttribute Wringable { get; set; }

        public ProductSimpleAttribute StrongAbsorbent { get; set; }

        public ProductSimpleAttribute Soft { get; set; }

        public ProductSimpleAttribute TadTechnology { get; set; }

        public ProductSimpleAttribute Biodegradable { get; set; }

        public ProductSimpleAttribute OrganicCotton { get; set; }

        public ProductSimpleAttribute Recyclable { get; set; }

        public ProductSimpleAttribute PefcCertified { get; set; }

        public ProductSimpleAttribute FscCertified { get; set; }

        public ProductSimpleAttribute Decorated { get; set; }

        public ProductSimpleAttribute Scent { get; set; }

        public string? SheetFormat { get; set; }

        public string? RetailFormat { get; set; }

        public string? Id { get; set; }

        public string? ProductBaseCode { get; set; }

        public string? ProductName { get; set; }

        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public string? Disclaimer { get; set; }

        public string[]? HighLights { get; set; }

        public string? BrandName { get; set; }

        public bool IsKeyProduct { get; set; }

        public string? Layer { get; set; }

        public string? Color { get; set; }

        public ProductSimpleAttribute Pattern { get; set; }

        public ProductSimpleAttribute WithLotion { get; set; }

        public ProductSimpleAttribute Flushable { get; set; }

        public string? MoistOrDry { get; set; }

        public List<string>? CrossReferences { get; set; }

        public List<string>? ScentVariants { get; set; }

        public string? ThirdPartyLogo { get; set; }

        public List<DomainProductAsset>? Assets { get; set; }

        public string? Ean { get; set; }

        public DomainProductStatus Status { get; set; }

        public List<IDomainProduct>? Children { get; set; }

        public string? SelectedProductId { get; set; }

        public string? MdrAddressManufacturer { get; set; }

        public string? MdrAddressVisitor { get; set; }

        public bool MdrCertificate { get; set; }

        public string? MdrMedicalDeviceLabel { get; set; }

        public override string ToString() => $"{ProductName} ({GetCode()})";

        public int GetCode()
        {
            string all = MergeAll(
                new string[]
                {
                    CastCollectionToString(CrossReferences),
                    CastCollectionToString(ScentVariants),
                    CastCollectionToString(HighLights),
                    CastCollectionToString(Children),
                    ProductName ?? string.Empty,
                    ShortDescription ?? string.Empty,
                    LongDescription ?? string.Empty,
                    Disclaimer ?? string.Empty,
                    BrandName ?? string.Empty,
                    Layer ?? string.Empty,
                    Color ?? string.Empty,
                    Pattern.ToString(),
                    WithLotion.ToString(),
                    Flushable.ToString(),
                    MoistOrDry ?? string.Empty,
                    ThirdPartyLogo ?? string.Empty,
                    CastCollectionToString(Assets),
                    CountUsageCU ?? string.Empty,
                    CountUsageCP ?? string.Empty,
                    PackCount ?? string.Empty,
                    Recyclable.ToString(),
                    OrganicCotton.ToString(),
                    CottonBuds.ToString(),
                    PocketPack.ToString(),
                    CubeFormat.ToString(),
                    SoftPack.ToString(),
                    Disposable.ToString(),
                    DermaTested.ToString(),
                    MachineResistable.ToString(),
                    SoftStrong.ToString(),
                    Wringable.ToString(),
                    StrongAbsorbent.ToString(),
                    Soft.ToString(),
                    TadTechnology.ToString(),
                    Biodegradable.ToString(),
                    PefcCertified.ToString(),
                    FscCertified.ToString(),
                    Scent.ToString(),
                    SheetFormat ?? string.Empty,
                    RetailFormat ?? string.Empty,
                    MdrAddressManufacturer ?? string.Empty,
                    MdrAddressVisitor ?? string.Empty,
                    MdrCertificate.ToString(),
                    MdrMedicalDeviceLabel ?? string.Empty
                });
            return all.GetHashCode();
        }

        private string MergeAll(string[] toMerge)
        {
            StringBuilder bi = new StringBuilder();
            for (int i = 0; i < toMerge.Length; i++)
            {
                bi.Append(toMerge[i]);
            }

            return bi.ToString();
        }

        private string CastCollectionToString<T>(List<T>? x)
        {
            if (x == null || x.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder returningString = new StringBuilder();
            for (int i = 0; i < x.Count; i++)
            {
                returningString.Append(x[i]?.ToString());
            }

            return returningString.ToString();
        }

        private string CastCollectionToString(string[]? x)
        {
            if (x == null || x.Length == 0)
            {
                return string.Empty;
            }

            return string.Join(string.Empty, x);
        }
    }
}