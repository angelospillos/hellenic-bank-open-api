using System.Text.Json.Serialization;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class MassCreditTransfer
{
    public int NumberOfTransactions { get; set; }
    public String? MessageId { get; set; }
    public String DebtorAccount { get; set; }
    [JsonPropertyName("debtorBic")] public String DebtorBIC { get; set; }
    public String? AmountSummary { get; set; }
    public List<MassCreditTransferPayment> Payments { get; set; }
}
