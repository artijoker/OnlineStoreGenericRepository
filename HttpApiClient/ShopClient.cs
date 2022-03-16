using HttpModels;
using System.Net.Http.Json;

namespace HttpApiClient
{
    public class ShopClient
    {
        private readonly string _host;
        private readonly HttpClient _httpClient;

        public ShopClient(string? host = null, HttpClient? httpClient = null)
        {
            _host = host ?? "https://localhost:7254";
            _httpClient = httpClient ?? new();
        }

        public Task<IReadOnlyList<Product>?> GetProducts() =>
            _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>($"{_host}/catalog/get_products");

        public Task<Product?> GetProductById(Guid id) =>
            _httpClient.GetFromJsonAsync<Product>($"{_host}/catalog/get_product_by_id?id={id}");

        public Task<HttpResponseMessage> AddProduct(Product product) =>
            _httpClient.PostAsJsonAsync($"{_host}/catalog/add_product", product);

        public Task<IReadOnlyList<Category>?> GetCategories() =>
            _httpClient.GetFromJsonAsync<IReadOnlyList<Category>>($"{_host}/catalog/get_categories");
        
        public Task<HttpResponseMessage> AddAccount(Account account) =>
            _httpClient.PostAsJsonAsync($"{_host}/account/add_account", account);
    }
}