using System.Text;
using HellenicBankOpenAPI.Hellenic;
using HellenicBankOpenAPI.Hellenic.Models;
using HellenicBankOpenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Refit;

namespace HellenicBankOpenAPI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppSettings _settings;
    private readonly ITokenClient _tokenClient;

    public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
        _tokenClient = Clients.CreateTokenClient(_settings.BaseAuthUrl);
    }

    public async Task<IActionResult> Index()
    {
        var code = Request.Query["code"];

        if (!String.IsNullOrEmpty(code))
        {
            _logger.LogInformation("got code {code}", code);

            var basicAuth = Clients.CreateBasicAuth(_settings);
            var queryParams = new TokenParams
            {
                Code = code,
                GrantType = "authorization_code",
                RedirectUri = _settings.RedirectUrl,
            };

            try
            {
                var token = await _tokenClient.ExchangeToken(
                    new Empty(),
                    basicAuth,
                    queryParams
                );

                // TODO: Save the token somewhere
                HttpContext.Session.Set("accessToken", Encoding.UTF8.GetBytes(token.AccessToken));
                HttpContext.Session.Set("refreshToken", Encoding.UTF8.GetBytes(token.RefreshToken));

                _logger.LogInformation("token {token}", token.AccessToken);

                ViewData["accessToken"] = token.AccessToken;
                ViewData["refreshToken"] = token.RefreshToken;

                _settings.AccessToken = token.AccessToken;

                return View();
            }
            catch (ApiException e)
            {
                _logger.LogError(e, $"error during refresh token exchange {e.Message}");
                return View("Error", new ErrorViewModel());
            }
        }

        return View();
    }
}
