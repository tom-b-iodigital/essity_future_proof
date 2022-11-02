using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Essity.ConsumerTissue.Connector.PCH.Config;
using Essity.ConsumerTissue.Connector.PCH.DDH;
using Essity.ConsumerTissue.Connector.PCH.DDH.Models;
using Essity.ConsumerTissue.Domain.Interfaces;
using Essity.ConsumerTissue.Domain.Models;
using RestSharp;

namespace Essity.ConsumerTissue.Connector.PCH.Services
{
    public class PchDdhService : IPchService
    {
        public PchDdhService()
        {
        }

        public async Task<CommunicationResult<T>> GetProducts<T>(PchSettingElement setting, string catalog, string lang, string brand)
            where T : IDomainProduct
        {
            if (setting == null)
            {
                throw new ArgumentNullException("setting", "Settings required to get products.");
            }

            if (catalog == null)
            {
                throw new ArgumentNullException("catalog", "Catalog required to get products.");
            }

            var result = Activator.CreateInstance<CommunicationResult<T>>();

            // https://fn-ddh-redis-prod.azurewebsites.net/api/RedisRead?brand=umbraco&tag=umbraco_bl_fr-be&key=edet_modified
            var client = new RestClient($"{setting.ApiUrl}/RedisRead?brand=umbraco&tag={catalog}_{lang}&key={brand}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            var cancellationTokenSource = new CancellationTokenSource();
            var response = await client.ExecuteAsync<List<DdhProduct>>(request, cancellationTokenSource.Token);

            if (response.ErrorException != null)
            {
                result.HasErrors = true;
                result.Error = response.ErrorException;
                return result;
            }

            if (response.Data == null)
            {
                result.HasErrors = true;
                result.Error = new Exception("The response data for this endpoint is null");
                return result;
            }

            result.HasErrors = false;

            if (!response.Data.Any())
            {
                // no error, but also no products
                result.Items = null;
                return result;
            }

            // cast products
            var allproducts = new List<T>();
            response.Data.ToList().ForEach(product =>
            {
                Debug.WriteLine("Product: " + product.ProductName + " KeyProduct: " + product.IsKeyProduct);
                var typedProduct = product.Convert<T>();

                // temporary workaround to set correct brand name - this is a sub-brand otherwise "Wisch & Weg" instead of "Zewa"
                typedProduct.BrandName = brand;
                allproducts.Add(typedProduct);
            });

            var mainProducts = allproducts.Where(x => x.IsKeyProduct).ToList();
            mainProducts.ForEach(mp =>
            {
                var children = allproducts.Where(x => x.ProductBaseCode == mp.ProductBaseCode && !x.IsKeyProduct);
                if (children.Any())
                {
                    mp.Children.AddRange(children as IEnumerable<IDomainProduct>);
                }
            });
            result.Items = mainProducts;

            return result;
        }
    }
}
