namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class RevenueEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Revenue/export";

        public static string GetAll = "api/v1/Revenue";
        public static string Delete = "api/v1/Revenue";
        public static string Save = "api/v1/Revenue";
        public static string GetCount = "api/v1/Revenue/count";
    }
}
//Kit_services