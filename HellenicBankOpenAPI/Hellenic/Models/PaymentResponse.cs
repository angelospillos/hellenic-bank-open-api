using System.Text.Json.Serialization;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class PaymentResponse
{
    [JsonPropertyName("payload")] public string Payload { get; set; } = String.Empty;
}
