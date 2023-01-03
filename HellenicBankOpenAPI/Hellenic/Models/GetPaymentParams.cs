using System.Text.Json.Serialization;
using Refit;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class GetCreditTransferParams
{
    [AliasAs("customerReference")] public string? CustomerReference { get; set; } = String.Empty;
}
