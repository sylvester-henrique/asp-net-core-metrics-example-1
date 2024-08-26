using Microsoft.AspNetCore.Mvc;
using ShopSports.Api.Repositories;
using ShopSports.Api.Services;

namespace ShopSports.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IPriceService _priceService;
        private readonly IInventoryService _inventoryService;

        public ProductsController(IProductRepository productRepository, IPriceService priceService, IInventoryService inventoryService)
        {
            _productRepository = productRepository;
            _priceService = priceService;
            _inventoryService = inventoryService;
        }

        public async Task<IActionResult> GetAsync()
        {
            var products = await _productRepository.GetAsync();

            var fillPricesTask = _priceService.FillPricesAsync(products);
            var fillAvailabilityTask = _inventoryService.FillAvailabilityAsync(products);
            await Task.WhenAll(fillPricesTask, fillAvailabilityTask);

            return Ok(products);
        }
    }
}
