using ShopSports.Api.Helpers;
using ShopSports.Api.Metrics;
using ShopSports.Api.Models;

namespace ShopSports.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductsMetrics _productsMetrics;

        public ProductRepository(IProductsMetrics productsMetrics)
        {
            _productsMetrics = productsMetrics;
        }

        private readonly Product[] _products = [
            new Product { Id = 1, Name = "Nike Air Max Shoes" },
            new Product { Id = 2, Name = "Adidas T-Shirt" },
            new Product { Id = 3, Name = "Puma Trinity Shoes" },
            new Product { Id = 4, Name = "Nike running shorts" },
            new Product { Id = 5, Name = "Tank top" },
        ];

        public async Task<IEnumerable<Product>> GetAsync()
        {
            try
            {
                await Delayer.ExecuteAsync(2000);
                ErrorGenerator.Execute(5, "Failed to get products");
                return _products;
            }
            catch (Exception)
            {
                _productsMetrics.RegisterError(GetProductError.QueryProducts);
                throw;
            }
        }
    }
}
