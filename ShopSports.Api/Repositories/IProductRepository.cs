using ShopSports.Api.Models;

namespace ShopSports.Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();
    }
}
