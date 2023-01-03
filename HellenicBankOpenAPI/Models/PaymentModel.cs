namespace HellenicBankOpenAPI.Models;

public class PaymentModel
{
    public String? AccessToken { get; set; } = String.Empty;
    public string Amount { get; set; } = String.Empty;
    public string Currency { get; set; } = String.Empty;
    public string DebtorAccount { get; set; } = String.Empty;
    public String? DebtorBic { get; set; } = String.Empty;
    public string BeneficiaryAccount { get; set; } = String.Empty;
    public string BeneficiaryName { get; set; } = String.Empty;
}
