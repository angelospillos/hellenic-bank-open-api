using Refit;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class TokenParams
{
    [AliasAs("grant_type")] public string GrantType { get; set; } = String.Empty;
    [AliasAs("redirect_uri")] public string RedirectUri { get; set; } = String.Empty;
    [AliasAs("code")] public string Code { get; set; } = String.Empty;
}
