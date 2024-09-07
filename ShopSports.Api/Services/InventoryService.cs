using ShopSports.Api.Helpers;
using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Random _random = new();

        public async Task FillAvailabilityAsync(IEnumerable<Product> products)
        {
            try
            {
                await Delayer.ExecuteAsync(500);
                ErrorGenerator.Execute("Failed to fill products availability.");

                foreach (var product in products)
                {
                    product.IsAvailable = _random.Next(2) == 1;
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
