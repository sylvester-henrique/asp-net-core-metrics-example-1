namespace ShopSports.Api.Helpers
{
    public static class ErrorGenerator
    {
        public static void Execute(int probability, string message)
        {
            var hasError = new Random().Next(0, 100) < probability;
            if (hasError)
            {
                throw new Exception(message);
            }
        }
    }
}
