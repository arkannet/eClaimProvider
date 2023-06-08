namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class CompanyEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Company/export";

        public static string GetAll = "api/v1/Company";
        public static string Delete = "api/v1/Company";
        public static string Save = "api/v1/Company";
        public static string GetCount = "api/v1/Company/count";
    }
}
//Kit_services