using System.Text.Json;
using HellenicBankOpenAPI.Hellenic;
using HellenicBankOpenAPI.Hellenic.Models;
using HellenicBankOpenAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Refit;

namespace HellenicBankOpenAPI.Controllers;

public class MassPaymentController : Controller
{
    private readonly ILogger<MassPaymentController> _logger;
    private readonly AppSettings _settings;
    private readonly IHellenicClient _hellenicClient;

    public MassPaymentController(ILogger<MassPaymentController> logger, IOptions<AppSettings> settings)
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
    public async Task<IActionResult> Index(MassPaymentModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        try
        {
            ViewData["accessToken"] = _settings.AccessToken;
            var transfer = new MassCreditTransfer
            {
                NumberOfTransactions = 2,
                MessageId = Guid.NewGuid().ToString().Replace("-", ""),
                DebtorAccount = model.DebtorAccount,
                DebtorBIC = model.DebtorBic ?? "HEBACY2NXXX", // HELLENIC
                AmountSummary = "100.00",
                Payments = new List<MassCreditTransferPayment>
                {
                    new()
                    {
                        // Schedule tomorrow, if execution date is not a working date then the transaction will
                        // be rejected
                        ExecutionDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                        Currency = "EUR",
                        Amount = "50.00",
                        BeneficiaryAccount = model.BeneficiaryAccount1,
                        BeneficiaryName = model.BeneficiaryName1,
                        BeneficiaryBankCountry = "CY",
                        BeneficiaryBankName = "Hellenic Bank",
                        BeneficiaryBankBIC = "HEBACY2NXXX",
                        CustomerReference = Guid.NewGuid().ToString().Replace("-", ""),
                        PaymentNotes = "Notes for payment",
                    },
                    new()
                    {
                        // Schedule tomorrow, if execution date is not a working date then the transaction will
                        // be rejected
                        ExecutionDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                        Amount = "50.00",
                        Currency = "EUR",
                        BeneficiaryAccount = model.BeneficiaryAccount2,
                        BeneficiaryName = model.BeneficiaryName2,
                        BeneficiaryBankCountry = "CY",
                        BeneficiaryBankName = "Hellenic Bank",
                        BeneficiaryBankBIC = "HEBACY2NXXX",
                        CustomerReference = Guid.NewGuid().ToString().Replace("-", ""),
                        PaymentNotes = "Notes for payment",
                    }
                },
            };

            var token = model.AccessToken;
            if (String.IsNullOrEmpty(token))
            {
                token = _settings.AccessToken;
            }

            var payment = await _hellenicClient.MassCreditTransfer(transfer, token, _settings.ClientId);
            _logger.LogInformation("Payment {0}", payment);
            ViewData["PaymentDetails"] = payment.Payload;

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
