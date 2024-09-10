using System.Diagnostics.Metrics;

namespace ShopSports.Api.Metrics
{
    public class ProductsMetrics : IProductsMetrics
    {
        private const string NAME = "Get.Products";
        private readonly Counter<long> _getProductsErrorCounter;

        public ProductsMetrics()
        {
            var getProdutcsErrorMeter = new Meter(NAME);
            _getProductsErrorCounter = getProdutcsErrorMeter.CreateCounter<long>("get.products.error.count");
        }

        public static string Name => NAME;

        public void RegisterError(GetProductError getProductError)
        {
            var tags = new KeyValuePair<string, object?>(nameof(getProductError), getProductError.ToString());
            _getProductsErrorCounter.Add(1, tags);
        }
    }
}
