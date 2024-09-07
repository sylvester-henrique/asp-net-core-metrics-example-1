using ShopSports.Api.Helpers;
using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public class PriceService : IPriceService
    {
        private readonly Random _random = new();

        public async Task FillPricesAsync(IEnumerable<Product> products)
        {
            try
            {
                var delay = new Random().Next(100, 500);
                await Task.Delay(delay);

                ErrorGenerator.Execute("Failed to fill product prices.");

                foreach (var product in products)
                {
                    var price = _random.Next(10000) / (decimal)100;
                    product.Price = price;
                }
            }
            catch (Exception)
            {
                // Register metric.
                throw;
            }
        }
    }
}
