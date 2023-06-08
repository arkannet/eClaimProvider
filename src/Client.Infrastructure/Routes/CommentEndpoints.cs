namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class CommentEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Comment/export";

        public static string GetAll = "api/v1/Comment";
        public static string Delete = "api/v1/Comment";
        public static string Save = "api/v1/Comment";
        public static string GetCount = "api/v1/Comment/count";
    }
}
//Kit_services