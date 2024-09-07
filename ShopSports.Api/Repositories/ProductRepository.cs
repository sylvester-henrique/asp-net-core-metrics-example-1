using ShopSports.Api.Helpers;
using ShopSports.Api.Models;

namespace ShopSports.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
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
                var delay = new Random().Next(100, 2000);
                await Task.Delay(delay);

                ErrorGenerator.Execute("Failed to get products");

                return _products;
            }
            catch (Exception)
            {
                // Register metric.
                throw;
            }
        }
    }
}
