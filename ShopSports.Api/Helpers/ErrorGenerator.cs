namespace ShopSports.Api.Helpers
{
    public static class ErrorGenerator
    {
        public static void Execute(string message)
        {
            var hasError = new Random().Next(0, 10) == 0;
            if (hasError)
            {
                throw new Exception(message);
            }
        }
    }
}
