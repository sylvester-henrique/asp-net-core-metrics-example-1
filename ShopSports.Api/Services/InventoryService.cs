using ShopSports.Api.Helpers;
using ShopSports.Api.Metrics;
using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductsMetrics _productsMetrics;

        public InventoryService(IProductsMetrics productsMetrics)
        {
            _productsMetrics = productsMetrics;
        }

        private readonly Random _random = new();

        public async Task FillAvailabilityAsync(IEnumerable<Product> products)
        {
            try
            {
                await Delayer.ExecuteAsync(500);
                ErrorGenerator.Execute(10, "Failed to fill products availability.");

                foreach (var product in products)
                {
                    product.IsAvailable = _random.Next(2) == 1;
                }
            }
            catch (Exception)
            {
                _productsMetrics.RegisterError(GetProductError.FillAvailability);
                throw;
            }
        }
    }
}
