using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using BlazorApp1.Interfaces;
using BlazorApp1.Models;
using Microsoft.Extensions.Options;

namespace BlazorApp1.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        public ProductService(HttpClient httpClient /*JsonSerializerOptions jsonOptions*/)
        {
            _httpClient = httpClient;
            //_jsonOptions = jsonOptions;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Product>?> Get()
        {
            var response = await _httpClient.GetAsync("v1/products");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Product>>(content, _jsonOptions);
        }

        public async Task Add(Product product)
        {
            var response = await _httpClient.PostAsync("v1/products", JsonContent.Create(product));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task Delete(long productId)
        {
            var response = await _httpClient.DeleteAsync($"v1/products/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }



    }
}
