namespace HellenicBankOpenAPI.Models;

public class AppSettings
{
    public const string ConfigKey = "AppSettings";

    public string BaseAuthUrl { get; set; } = String.Empty;
    public string BaseApiUrl { get; set; } = String.Empty;
    public string ClientId { get; set; } = String.Empty;
    public string ClientSecret { get; set; } = String.Empty;
    public string RedirectUrl { get; set; } = String.Empty;
    public string AccessToken { get; set; } = String.Empty;
    public string RefreshToken { get; set; } = String.Empty;
}
