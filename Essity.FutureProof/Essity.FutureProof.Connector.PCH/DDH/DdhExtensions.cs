using Essity.FutureProof.Connector.PCH.DDH.Models;
using Essity.FutureProof.Domain.Enums;
using Essity.FutureProof.Domain.Interfaces;
using Essity.FutureProof.Domain.Models;

namespace Essity.FutureProof.Connector.PCH.DDH
{
    public static class DdhExtensions
    {
        public static T Convert<T>(this DdhProduct product)
            where T : IDomainProduct
        {
            var toReturn = Activator.CreateInstance<T>();
            toReturn.Id = product.ProductId;
            toReturn.SelectedProductId = product.ProductId;
            toReturn.ProductBaseCode = product.ProductBaseCode;

            toReturn.PackCount = string.IsNullOrEmpty(product.PackCount) ? "0" : product.PackCount;
            toReturn.CountUsageCP = string.IsNullOrEmpty(product.CountUsageCP) ? "0" : product.CountUsageCP;
            toReturn.CountUsageCU = string.IsNullOrEmpty(product.CountUsageCU) ? "0" : product.CountUsageCU;

            toReturn.ProductName = product.ProductName;
            toReturn.ShortDescription = product.ShortDescription?.Replace(Environment.NewLine, "<br/>").Trim();
            toReturn.LongDescription = product.LongDescription?.Replace(Environment.NewLine, " <br/>").Trim();
            toReturn.Status = DomainProductStatus.UnChanged; // default status

            toReturn.BrandName = product.BrandName;

            toReturn.HighLights = product.Highlights != null && product.Highlights.Any() ? product.Highlights.ToArray() : null;

            toReturn.Disclaimer = product.Disclaimer?.Replace("<br>", "\r\n").TrimStart(new char[] { '*', ' ' });

            toReturn.IsKeyProduct = product.IsKeyProduct;

            toReturn.Disposable = ConvertBoolToSimpleAttribute(product.Disposable);
            toReturn.DermaTested = ConvertBoolToSimpleAttribute(product.DermaTested);
            toReturn.MachineResistable = ConvertBoolToSimpleAttribute(product.MachineResistable);
            toReturn.SoftStrong = ConvertBoolToSimpleAttribute(product.SoftStrong);
            toReturn.Wringable = ConvertBoolToSimpleAttribute(product.Wringable);
            toReturn.TadTechnology = ConvertBoolToSimpleAttribute(product.TadTechnology);
            toReturn.StrongAbsorbent = ConvertBoolToSimpleAttribute(product.StrongAbsorbent);
            toReturn.Soft = ConvertBoolToSimpleAttribute(product.Soft);
            toReturn.SoftPack = ConvertBoolToSimpleAttribute(product.SoftPack);
            toReturn.PocketPack = ConvertBoolToSimpleAttribute(product.PocketPack);
            toReturn.CubeFormat = ConvertBoolToSimpleAttribute(product.CubeFormat);
            toReturn.Scent = ConvertBoolToSimpleAttribute(product.Scent);
            toReturn.SheetFormat = product.SheetFormat;
            toReturn.RetailFormat = product.RetailFormat;
            toReturn.Biodegradable = ConvertBoolToSimpleAttribute(product.Biodegradable);
            toReturn.PefcCertified = ConvertBoolToSimpleAttribute(product.PefcCertified);
            toReturn.FscCertified = ConvertBoolToSimpleAttribute(product.FscCertified);
            toReturn.OrganicCotton = ConvertBoolToSimpleAttribute(product.OrganicCotton);
            toReturn.Recyclable = ConvertBoolToSimpleAttribute(product.Recyclable);
            toReturn.CottonBuds = ConvertBoolToSimpleAttribute(product.CottonBuds);
            toReturn.Layer = product.Layer;
            var color = product.Color;
            toReturn.Color = color;
            if (!string.IsNullOrEmpty(color))
            {
                // use color for Umbraco decorated as well
                toReturn.Decorated = color.ToLower().Contains("decor") ? ProductSimpleAttribute.Yes : ProductSimpleAttribute.NotSet;
            }

            toReturn.Pattern = ConvertBoolToSimpleAttribute(product.Pattern);
            toReturn.WithLotion = ConvertBoolToSimpleAttribute(product.WithLotion);
            toReturn.Flushable = ConvertBoolToSimpleAttribute(product.Flushable);
            toReturn.MoistOrDry = product.Moistness;
            toReturn.CrossReferences = product.CrossReferences?.ToList();
            toReturn.ScentVariants = product.ScentVariants?.ToList();
            toReturn.Assets = GetAssets(product.Assets);
            toReturn.Ean = product.Ean?.Trim();

            // set default
            toReturn.MdrCertificate = false;

            if (!string.IsNullOrEmpty(product.MdrAddressManufacturer) && !string.IsNullOrEmpty(product.MdrAddressVisitor) && !string.IsNullOrEmpty(product.MdrMedicalDeviceLabel))
            {
                toReturn.MdrCertificate = true;
                toReturn.MdrAddressManufacturer = product.MdrAddressManufacturer;
                toReturn.MdrAddressVisitor = product.MdrAddressVisitor;
                toReturn.MdrMedicalDeviceLabel = product.MdrMedicalDeviceLabel;
            }

            return toReturn;
        }

        private static List<DomainProductAsset>? GetAssets(IEnumerable<IEnumerable<Asset>>? assets)
        {
            if (assets == null || !assets.Any())
            {
                return null;
            }

            int i = 0;
            var returns = assets.SelectMany(a =>
                {
                    i++;
                    return a.Where(x => x.FormatId != null).Select(x =>
                            new DomainProductAsset()
                            {
                                Name = $"asset-{i}",
                                Value = x.Url,
                                AssetType = x.ShotType?.Any() ?? false ?
                                    x.ShotType.Select(y => y.ShotTypeId).ToList().Contains(10004) ?
                                            DomainProductAssetType.Main
                                            : x.ShotType.Select(y => y.ShotTypeId).ToList().Contains(10005) ? DomainProductAssetType.Alternate : DomainProductAssetType.Regular
                                    : DomainProductAssetType.Regular,
                                Rendition = (RenditionType)Enum.Parse(typeof(RenditionType), Enum.GetName(typeof(RenditionType), int.Parse(x.FormatId!))!)
                            });
                });

            return returns.ToList();
        }

        private static ProductSimpleAttribute ConvertBoolToSimpleAttribute(bool? value)
        {
            if (value.HasValue == false)
            {
                return ProductSimpleAttribute.NotSet;
            }

            if (value.Value == false)
            {
                return ProductSimpleAttribute.No;
            }

            return ProductSimpleAttribute.Yes;
        }
    }
}