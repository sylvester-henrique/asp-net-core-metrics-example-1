using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public class PriceService : IPriceService
    {
        private readonly Random _random = new ();

        public async Task FillPricesAsync(IEnumerable<Product> products)
        {
            var delay = _random.Next(1000);
            await Task.Delay(delay);

            foreach (var product in products)
            {
                var price = _random.Next(10000) / (decimal)100;
                product.Price = price;
            }
        }
    }
}
