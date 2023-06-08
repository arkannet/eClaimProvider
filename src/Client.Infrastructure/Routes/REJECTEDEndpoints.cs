namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class REJECTEDEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/REJECTED/export";

        public static string GetAll = "api/v1/REJECTED";
        public static string Delete = "api/v1/REJECTED";
        public static string Save = "api/v1/REJECTED";
        public static string GetCount = "api/v1/REJECTED/count";
    }
}
//Kit_services