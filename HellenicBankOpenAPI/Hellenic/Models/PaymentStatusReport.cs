namespace HellenicBankOpenAPI.Hellenic.Models;

public class PaymentStatusReport
{
    public String ClientId { get; set; }
    public String BusinessId { get; set; }
    public String SubscriberId { get; set; }
    public String DebtorBic { get; set; }
    public String DebtorAccount { get; set; }
    public String ApiId { get; set; }
    public String CustomerReference { get; set; }
    public String ExecutionDate { get; set; }
    public String ValueDate { get; set; }
    public String Currency { get; set; }
    public Decimal Amount { get; set; }
    public String BeneficiaryName { get; set; }
    public String BeneficiaryAccount { get; set; }
    public String BeneficiaryAddress { get; set; }
    public String BeneficiaryCountry { get; set; }
    public String PaymentNotes { get; set; }
    public String BeneficiaryBankBic { get; set; }
    public String BeneficiaryBankName { get; set; }
    public String BeneficiaryBankAddress { get; set; }
    public String BeneficiaryBankCountry { get; set; }
    public Decimal Charges { get; set; }
    public String IntermediaryInstitutionBic { get; set; }
    public String ClearingHouseCode { get; set; }
    public String CreationDateTime { get; set; }
    public String PaymentType { get; set; }
    public String FaxConfirmation { get; set; }
    public String EmailConfirmation { get; set; }
    public String TransactionUrgency { get; set; }
    public PaymentStatus PaymentResponse { get; set; }
}
