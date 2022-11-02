using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using Essity.FutureProof.Connector.PCH.Config;
using Essity.FutureProof.Connector.PCH.DDH;
using Essity.FutureProof.Connector.PCH.DDH.Models;
using Essity.FutureProof.Domain.Interfaces;
using Essity.FutureProof.Domain.Models;
using Microsoft.Net.Http.Headers;

namespace Essity.FutureProof.Connector.PCH.Services.Implementations
{
    public class PchDdhService : IPchService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PchDdhService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CommunicationResult<T>> GetProducts<T>(PchSettingElement setting, string catalog, string lang, string brand)
            where T : IDomainProduct
        {
            try
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

                //var response = await client.ExecuteAsync<List<DdhProduct>>(request, cancellationTokenSource.Token);

                // https://fn-ddh-redis-prod.azurewebsites.net/api/RedisRead?brand=umbraco&tag=umbraco_bl_fr-be&key=edet_modified
                var cancellationTokenSource = new CancellationTokenSource();
                var httpRequestMessage = new HttpRequestMessage(
                    HttpMethod.Get,
                    $"{setting.ApiUrl}/RedisRead?brand=umbraco&tag={catalog}_{lang}&key={brand}")
                {
                    Headers =
                    {
                        { HeaderNames.CacheControl, "no-cache" },
                    }
                };

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationTokenSource.Token);

                httpResponseMessage.EnsureSuccessStatusCode();

                using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                List<DdhProduct>? responseData = await JsonSerializer.DeserializeAsync<List<DdhProduct>>(contentStream);

                if (responseData == null)
                {
                    result.HasErrors = true;
                    result.Error = new Exception("The response data for this endpoint is null");
                    return result;
                }

                result.HasErrors = false;

                if (!responseData.Any())
                {
                    // no error, but also no products
                    result.Items = null;
                    return result;
                }

                // cast products
                var allproducts = new List<T>();
                responseData.ToList().ForEach(product =>
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
                    IEnumerable<T>? children = allproducts.Where(x => x.ProductBaseCode == mp.ProductBaseCode && !x.IsKeyProduct);
                    if (children.Any())
                    {
                        mp.Children?.AddRange(children as IEnumerable<IDomainProduct> ?? new List<IDomainProduct>());
                    }
                });
                result.Items = mainProducts;

                return result;
            }
            catch (Exception ex)
            {
                var result = Activator.CreateInstance<CommunicationResult<T>>();

                result.HasErrors = true;
                result.Error = ex;
                return result;
            }
        }
    }
}