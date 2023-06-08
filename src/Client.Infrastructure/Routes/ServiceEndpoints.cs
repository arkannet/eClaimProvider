namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class ServiceEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Service/export";

        public static string GetAll = "api/v1/Service";
        public static string Delete = "api/v1/Service";
        public static string Save = "api/v1/Service";
        public static string GetCount = "api/v1/Service/count";
    }
}
//Kit_services