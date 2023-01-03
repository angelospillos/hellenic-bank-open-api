using System.Diagnostics;
using HellenicBankOpenAPI.Hellenic;
using Microsoft.AspNetCore.Mvc;
using HellenicBankOpenAPI.Models;
using Microsoft.Extensions.Options;

namespace HellenicBankOpenAPI.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly AppSettings _settings;
    private readonly IHellenicClient _hellenicClient;

    public AuthController(ILogger<AuthController> logger, IOptions<AppSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
        _hellenicClient = Clients.CreateHellenicClient(_settings.BaseApiUrl);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Connect()
    {
        var url = string.Format(
            "{0}/oauth2/auth?response_type=code&client_id={1}&redirect_uri={2}&scope={3}&state=",
            _settings.BaseAuthUrl,
            _settings.ClientId,
            _settings.RedirectUrl,
            "b2b.account.list," // List accounts
            + "b2b.credit.transfer.single," // Single payment
            + "b2b.report.credit.transfer.single," // Single payment status 
            + "b2b.credit.transfer.mass," // Mass payment 
            + "b2b.report.credit.transfer.mass" // Mass payment status
        );

        _logger.LogInformation("redirecting to {url}", url);
        return Redirect(url);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
