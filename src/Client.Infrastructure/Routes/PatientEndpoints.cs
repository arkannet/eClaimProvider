namespace eClaimProvider.Client.Infrastructure.Routes
{
    public static class PatientEndpoints
    {
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public static string Export = "api/v1/Patient/export";

        public static string GetAll = "api/v1/Patient";
        public static string Delete = "api/v1/Patient";
        public static string Save = "api/v1/Patient";
        public static string GetCount = "api/v1/Patient/count";
    }
}
//Kit_services