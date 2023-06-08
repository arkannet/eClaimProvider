namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class InvoiceEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Invoice/export";

        public static string GetAll = "api/v1/Invoice";
        public static string Delete = "api/v1/Invoice";
        public static string Save = "api/v1/Invoice";
        public static string GetCount = "api/v1/Invoice/count";
    }
}
//Kit_services