using System.Text.Json.Serialization;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class CreditTransfer
{
    [JsonPropertyName("executionDate")] public String ExecutionDate { get; set; }
    public String Amount { get; set; }
    public String Currency { get; set; }
    public String DebtorAccount { get; set; }
    [JsonPropertyName("debtorBic")] public String DebtorBic { get; set; }
    public String BeneficiaryAccount { get; set; }
    public String BeneficiaryName { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? BeneficiaryAddress { get; set; }

    public String BeneficiaryBankCountry { get; set; }
    public String BeneficiaryBankName { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? BeneficiaryBankAddress { get; set; }

    [JsonPropertyName("beneficiaryBankBic")]
    public String BeneficiaryBankBic { get; set; }

    public String CustomerReference { get; set; }

    public String PaymentNotes { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? ClearingHouseCode { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? TransactionUrgency { get; set; }

    [JsonPropertyName("intermediaryInstitutionBic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? IntermediaryInstitutionBIC { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? Charges { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? EmailConfirmation { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? FaxConfirmation { get; set; }
}
