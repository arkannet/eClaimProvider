namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class ResultEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Result/export";

        public static string GetAll = "api/v1/Result";
        public static string Delete = "api/v1/Result";
        public static string Save = "api/v1/Result";
        public static string GetCount = "api/v1/Result/count";
    }
}
//Kit_services