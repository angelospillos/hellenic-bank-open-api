using System.Text.Json.Serialization;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class TokenResponse
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = String.Empty;
    [JsonPropertyName("refresh_token")] public string RefreshToken { get; set; } = String.Empty;
    [JsonPropertyName("client_id")] public string ClientId { get; set; } = String.Empty;
    [JsonPropertyName("created_on")] public long CreatedAt { get; set; } = 0;
    [JsonPropertyName("expires_at")] public long ExpiresAt { get; set; } = 0;
    [JsonPropertyName("scope")] public List<string> Scope { get; set; } = new();
    [JsonPropertyName("token_type")] public string TokenType { get; set; } = String.Empty;
}
