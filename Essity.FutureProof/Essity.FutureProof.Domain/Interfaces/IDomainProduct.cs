using Essity.FutureProof.Domain.Enums;
using Essity.FutureProof.Domain.Models;

namespace Essity.FutureProof.Domain.Interfaces
{
    public interface IDomainProduct
    {
        string? CountUsageCU { get; set; }

        string? CountUsageCP { get; set; }

        string? PackCount { get; set; }

        ProductSimpleAttribute CottonBuds { get; set; }

        ProductSimpleAttribute PocketPack { get; set; }

        ProductSimpleAttribute CubeFormat { get; set; }

        ProductSimpleAttribute SoftPack { get; set; }

        ProductSimpleAttribute Disposable { get; set; }

        ProductSimpleAttribute Decorated { get; set; }

        ProductSimpleAttribute DermaTested { get; set; }

        ProductSimpleAttribute MachineResistable { get; set; }

        ProductSimpleAttribute SoftStrong { get; set; }

        ProductSimpleAttribute Wringable { get; set; }

        ProductSimpleAttribute StrongAbsorbent { get; set; }

        ProductSimpleAttribute Soft { get; set; }

        ProductSimpleAttribute TadTechnology { get; set; }

        ProductSimpleAttribute Biodegradable { get; set; }

        ProductSimpleAttribute OrganicCotton { get; set; }

        ProductSimpleAttribute Recyclable { get; set; }

        ProductSimpleAttribute PefcCertified { get; set; }

        ProductSimpleAttribute FscCertified { get; set; }

        ProductSimpleAttribute Scent { get; set; }

        string? SheetFormat { get; set; }

        string? RetailFormat { get; set; }

        string? Id { get; set; }

        string? SelectedProductId { get; set; }

        string? ProductBaseCode { get; set; }

        string? ProductName { get; set; }

        string? ShortDescription { get; set; }

        string? LongDescription { get; set; }

        string? Disclaimer { get; set; }

        string[]? HighLights { get; set; }

        string? BrandName { get; set; }

        bool IsKeyProduct { get; set; }

        string? Layer { get; set; }

        string? Color { get; set; }

        ProductSimpleAttribute Pattern { get; set; }

        ProductSimpleAttribute WithLotion { get; set; }

        ProductSimpleAttribute Flushable { get; set; }

        string? MoistOrDry { get; set; }

        DomainProductStatus Status { get; set; }

        List<string>? CrossReferences { get; set; }

        List<string>? ScentVariants { get; set; }

        string? ThirdPartyLogo { get; set; }

        List<DomainProductAsset>? Assets { get; set; }

        string? Ean { get; set; }

        string? MdrAddressManufacturer { get; set; }

        string? MdrAddressVisitor { get; set; }

        bool MdrCertificate { get; set; }

        string? MdrMedicalDeviceLabel { get; set; }

        List<IDomainProduct>? Children { get; set; }

        int GetCode();
    }
}