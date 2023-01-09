using HellenicBankOpenAPI.Hellenic;
using HellenicBankOpenAPI.Hellenic.Models;
using HellenicBankOpenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Refit;

namespace HellenicBankOpenAPI.Controllers;

public class SinglePaymentController : Controller
{
    private readonly ILogger<SinglePaymentController> _logger;
    private readonly AppSettings _settings;
    private readonly IHellenicClient _hellenicClient;

    public SinglePaymentController(ILogger<SinglePaymentController> logger, IOptions<AppSettings> settings)
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
    public async Task<IActionResult> Index(PaymentModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        try
        {
            ViewData["accessToken"] = _settings.AccessToken;
            var transfer = new CreditTransfer
            {
                // Schedule tomorrow, if execution date is not a working date then the transaction will
                // be rejected
                ExecutionDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                Amount = model.Amount,
                Currency = model.Currency,
                DebtorAccount = model.DebtorAccount,
                DebtorBic = model.DebtorBic ?? "HEBACY2NXXX", // HELLENIC
                BeneficiaryAccount = model.BeneficiaryAccount,
                BeneficiaryName = model.BeneficiaryName,
                BeneficiaryBankCountry = "CY",
                BeneficiaryBankName = "Hellenic Bank",
                BeneficiaryBankBic = "HEBACY2NXXX",
                CustomerReference = Guid.NewGuid().ToString().Replace("-", ""),
                PaymentNotes = "Notes for payment",
            };

            var token = model.AccessToken;
            if (String.IsNullOrEmpty(token))
            {
                token = _settings.AccessToken;
            }

            var payment = await _hellenicClient.CreditTransfer(transfer, token, _settings.ClientId);
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
