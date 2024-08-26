using ShopSports.Api.Models;

namespace ShopSports.Api.Services
{
    public interface IInventoryService
    {
        Task FillAvailabilityAsync(IEnumerable<Product> products);
    }
}
