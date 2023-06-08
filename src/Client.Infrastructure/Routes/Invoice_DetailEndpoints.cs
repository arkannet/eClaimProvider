namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class Invoice_DetailEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Invoice_Detail/export";

        public static string GetAll = "api/v1/Invoice_Detail";
        public static string Delete = "api/v1/Invoice_Detail";
        public static string Save = "api/v1/Invoice_Detail";
        public static string GetCount = "api/v1/Invoice_Detail/count";
    }
}
//Kit_services