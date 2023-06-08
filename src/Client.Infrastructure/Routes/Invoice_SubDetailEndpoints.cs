namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class Invoice_SubDetailEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Invoice_SubDetail/export";

        public static string GetAll = "api/v1/Invoice_SubDetail";
        public static string Delete = "api/v1/Invoice_SubDetail";
        public static string Save = "api/v1/Invoice_SubDetail";
        public static string GetCount = "api/v1/Invoice_SubDetail/count";
    }
}
//Kit_services