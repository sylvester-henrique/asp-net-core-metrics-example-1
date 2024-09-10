namespace ShopSports.Api.Metrics
{
    public interface IProductsMetrics : ICustomMetric
    {
        void RegisterError(GetProductError getProductError);
    }
}
