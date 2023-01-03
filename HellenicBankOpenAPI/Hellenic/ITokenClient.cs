using HellenicBankOpenAPI.Hellenic.Models;
using Refit;

namespace HellenicBankOpenAPI.Hellenic;

public interface ITokenClient
{
    // The empty body is meant to force the token params to 
    [Post("/token/exchange")]
    Task<TokenResponse> ExchangeToken(
        [Body] Empty body,
        [Header("Authorization")] string authorization,
        [Query] TokenParams tokenParams
    );
}
