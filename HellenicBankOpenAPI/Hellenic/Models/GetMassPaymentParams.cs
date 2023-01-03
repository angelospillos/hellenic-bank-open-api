using System.Text.Json.Serialization;
using Refit;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class GetMassCreditTransferParams
{
    [AliasAs("messageId")] public string? MessageId { get; set; } = String.Empty;
}
