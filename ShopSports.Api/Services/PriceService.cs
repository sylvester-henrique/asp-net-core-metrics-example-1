using ShopSports.Api.Helpers;
using ShopSports.Api.Metrics;
using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public class PriceService : IPriceService
    {
        private readonly IProductsMetrics _productsMetrics;

        public PriceService(IProductsMetrics productsMetrics)
        {
            _productsMetrics = productsMetrics;
        }

        private readonly Random _random = new();

        public async Task FillPricesAsync(IEnumerable<Product> products)
        {
            try
            {
                await Delayer.ExecuteAsync(500);
                ErrorGenerator.Execute(20, "Failed to fill product prices.");

                foreach (var product in products)
                {
                    var price = _random.Next(10000) / (decimal)100;
                    product.Price = price;
                }
            }
            catch (Exception)
            {
                _productsMetrics.RegisterError(GetProductError.FillPrices);
                throw;
            }
        }
    }
}
