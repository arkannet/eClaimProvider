namespace eClaimProvider.Shared.Constants.Application
{
    public static class ApplicationConstants
    {
        public static class SignalR
        {
            public const string HubUrl = "/signalRHub";
            public const string SendUpdateDashboard = "UpdateDashboardAsync";
            public const string ReceiveUpdateDashboard = "UpdateDashboard";
            public const string SendRegenerateTokens = "RegenerateTokensAsync";
            public const string ReceiveRegenerateTokens = "RegenerateTokens";
            public const string ReceiveChatNotification = "ReceiveChatNotification";
            public const string SendChatNotification = "ChatNotificationAsync";
            public const string ReceiveMessage = "ReceiveMessage";
            public const string SendMessage = "SendMessageAsync";

            public const string OnConnect = "OnConnectAsync";
            public const string ConnectUser = "ConnectUser";
            public const string OnDisconnect = "OnDisconnectAsync";
            public const string DisconnectUser = "DisconnectUser";
            public const string OnChangeRolePermissions = "OnChangeRolePermissions";
            public const string LogoutUsersByRole = "LogoutUsersByRole";
        }
        public static class Cache
        {
            public const string GetAllBrandsCacheKey = "all-brands";
            public const string GetAllDocumentTypesCacheKey = "all-document-types";
            public const string GetAllInvoiceCacheKey = "all-Invoices";
            public const string GetAllPatientCacheKey = "all-Patients";
            public const string GetAllInvoice_SubDetailCacheKey = "all-Invoice_SubDetails";
            public const string GetAllCompanyCacheKey = "all-Companies";
            public const string GetAllCommentCacheKey = "all-Comments";
            public const string GetAllInvoice_DetailCacheKey = "all-Invoice_Details";
            public const string GetAllRevenueCacheKey = "all-Revenues";
            public const string GetAllREJECTEDCacheKey = "all-REJECTEDs";
            public const string GetAllResultCacheKey = "all-Results";
            public const string GetAllServiceCacheKey = "all-Services";
            //Invoice Company   Comment Invoice_Detail  Revenue
            public static string GetAllEntityExtendedAttributesCacheKey(string entityFullName)
            {
                return $"all-{entityFullName}-extended-attributes";
            }

            public static string GetAllEntityExtendedAttributesByEntityIdCacheKey<TEntityId>(string entityFullName, TEntityId entityId)
            {
                return $"all-{entityFullName}-extended-attributes-{entityId}";
            }
        }

        public static class MimeTypes
        {
            public const string OpenXml = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        }
    }
}