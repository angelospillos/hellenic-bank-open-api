namespace HellenicBankOpenAPI.Models;

public class MassPaymentModel
{
    public String? AccessToken { get; set; } = String.Empty;
    public string DebtorAccount { get; set; } = String.Empty;
    public String? DebtorBic { get; set; } = String.Empty;
    public string BeneficiaryAccount1 { get; set; } = String.Empty;
    public string BeneficiaryName1 { get; set; } = String.Empty;
    public string BeneficiaryAccount2 { get; set; } = String.Empty;
    public string BeneficiaryName2 { get; set; } = String.Empty;
}
