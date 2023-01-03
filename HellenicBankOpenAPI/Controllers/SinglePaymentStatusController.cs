using System.Text.Json;
using HellenicBankOpenAPI.Hellenic;
using HellenicBankOpenAPI.Hellenic.Models;
using HellenicBankOpenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Refit;

namespace HellenicBankOpenAPI.Controllers;

public class SinglePaymentStatusController : Controller
{
    private readonly ILogger<SinglePaymentStatusController> _logger;
    private readonly AppSettings _settings;
    private readonly IHellenicClient _hellenicClient;

    public SinglePaymentStatusController(ILogger<SinglePaymentStatusController> logger, IOptions<AppSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
        _hellenicClient = Clients.CreateHellenicClient(_settings.BaseApiUrl);
    }

    public IActionResult Index()
    {
        ViewData["accessToken"] = _settings.AccessToken;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(PaymentStatusModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        try
        {
            ViewData["accessToken"] = _settings.AccessToken;

            var accessToken = _settings.AccessToken;

            if (!String.IsNullOrEmpty(model.AccessToken))
            {
                accessToken = model.AccessToken;
            }

            var getParams = new GetCreditTransferParams
            {
                CustomerReference = model.PaymentId.Trim(),
            };

            var payment = await _hellenicClient.GetCreditTransfer(accessToken, _settings.ClientId, getParams);
            _logger.LogInformation("Payment {0}", payment);
            ViewData["PaymentDetails"] = JsonSerializer.Serialize(payment);
            return View(model);
        }
        catch (ApiException e)
        {
            _logger.LogError(e, $"error during payment {e.Message}");
            // Show error in error view 
            ViewData["ErrorMessage"] = e.Message;
            ViewData["ErrorDetail"] = e.Content;
            return View("Error", new ErrorViewModel());
        }
    }
}
