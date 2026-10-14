namespace CraftPlatform.Inventory.Api.EndPoints.Transactions
{
    public static class TransactionRoutes
    {
        public const string BaseUrl = "/transactions";
        public const string Delete = BaseUrl + "/{transactionId}";
        public const string ReadById = BaseUrl + "/{transactionId}";
        public const string Update = BaseUrl + "/{transactionId}";
    }
}
