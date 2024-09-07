namespace ShopSports.Api.Helpers
{
    public static class Delayer
    {
        public static async Task ExecuteAsync(int maxDelayInMs)
        {
            var delay = new Random().Next(100, maxDelayInMs);
            await Task.Delay(delay);
        }
    }
}
