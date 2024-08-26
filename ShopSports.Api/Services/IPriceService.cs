using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public interface IPriceService
    {
        Task FillPricesAsync(IEnumerable<Product> products);
    }
}
