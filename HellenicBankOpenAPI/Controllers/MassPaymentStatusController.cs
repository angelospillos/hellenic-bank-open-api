using HellenicBankOpenAPI.Hellenic;
using HellenicBankOpenAPI.Hellenic.Models;
using HellenicBankOpenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Refit;

namespace HellenicBankOpenAPI.Controllers;

public class MassPaymentStatusController : Controller
{
    private readonly ILogger<MassPaymentStatusController> _logger;
    private readonly AppSettings _settings;
    private readonly IHellenicClient _hellenicClient;

    public MassPaymentStatusController(ILogger<MassPaymentStatusController> logger, IOptions<AppSettings> settings)
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

            var getParams = new GetMassCreditTransferParams
            {
                MessageId = model.PaymentId.Trim(),
            };

            var payment = await _hellenicClient.GetMassCreditTransfer(accessToken, _settings.ClientId, getParams);
            _logger.LogInformation("Payment {0}", payment);
            ViewData["PaymentDetails"] = JsonConvert.SerializeObject(payment, Formatting.Indented);;
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
