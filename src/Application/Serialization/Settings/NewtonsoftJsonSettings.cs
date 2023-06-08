
using eClaimProvider.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace eClaimProvider.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}