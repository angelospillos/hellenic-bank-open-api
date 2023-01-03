namespace HellenicBankOpenAPI.Hellenic.Models;

public class MassPaymentStatusReport
{
    public String ClientId { get; set; }
    public String BusinessId { get; set; }
    public String SubscriberId { get; set; }
    public String MessageId { get; set; }
    public Decimal NumberOfTransactions { get; set; }
    public Decimal AmountSummary { get; set; }
    public String DebtorBic { get; set; }
    public String DebtorAccount { get; set; }
    public String DebitCurrency { get; set; }
    public List<MassPaymentStatusReportTransaction> Payments { get; set; }
}

public class MassPaymentStatusReportTransaction
{
    public String ApiId { get; set; }
    public String CustomerReference { get; set; }
    public String ExecutionDate { get; set; }
    public String ValueDate { get; set; }
    public String Currency { get; set; }
    public Decimal Amount { get; set; }
    public String BeneficiaryName { get; set; }
    public String BeneficiaryAccount { get; set; }
    public String PaymentNotes { get; set; }
    public String BeneficiaryBankBic { get; set; }
    public String CreationDateTime { get; set; }
    public String TransactionUrgency { get; set; }
    public String ActionAllowed { get; set; }
    public PaymentStatus PaymentResponse { get; set; }
}
