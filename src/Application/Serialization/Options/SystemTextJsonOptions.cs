using System.Text.Json;
using eClaimProvider.Application.Interfaces.Serialization.Options;

namespace eClaimProvider.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}