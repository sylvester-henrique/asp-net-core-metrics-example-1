using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Random _random = new();

        public async Task FillAvailabilityAsync(IEnumerable<Product> products)
        {
            var delay = _random.Next(750);
            await Task.Delay(delay);
            foreach (var product in products)
            {
                product.IsAvailable = _random.Next(2) == 1;
            }
        }
    }
}
