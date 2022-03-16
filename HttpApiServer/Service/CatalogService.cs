
using HttpModels;

namespace HttpApiServer
{
    public class CatalogService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClock _clock;

        public CatalogService(IProductRepository productRepository, ICategoryRepository categoryRepository, IClock clock)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _clock = clock;
        }

        public async Task AddProduct(Product product)
        {
            var category = await _categoryRepository.GetById(product.CategoryId);

            product.Id = Guid.NewGuid();
            await _productRepository.Add(product);
            category.Products.Add(product);
            await _categoryRepository.Update(category);
        }

        public async Task<IReadOnlyList<Product>> GetProducts(string? userAgent)
        {
            decimal percent = GetPercent(userAgent, _clock.GetClock());
            var products = await _productRepository.GetAll();
            return products.Select(p =>
            {
                p.Price += (percent == 0 ? 0 : (p.Price / 100) * percent);
                return p;
            }).ToList();
        }

        public async Task<IReadOnlyList<Category>> GetCategories()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Product> GetProductById(string? userAgent, Guid id)
        {
            decimal percent = GetPercent(userAgent, _clock.GetClock());
            var products = await _productRepository.GetById(id);
            products.Price += (percent == 0 ? 0 : (products.Price / 100) * percent);
            return products;
        }

        private static int GetPercent(string? userAgent = null, DateTime? date = null)
        {
            var dateTime = date ?? DateTime.Now;
            var percent = 0;
            percent -= dateTime.DayOfWeek == DayOfWeek.Wednesday ? 50 : 0;
            percent += dateTime.DayOfWeek == DayOfWeek.Friday ? 50 : 0;
            if (userAgent is not null)
            {
                userAgent = userAgent.ToLower();
                percent -= userAgent.Contains("android") ? 10 : 0;
                percent += userAgent.Contains("iphone") || userAgent.Contains("ipad") ? 50 : 0;
            }

            return percent;
        }
    }
}