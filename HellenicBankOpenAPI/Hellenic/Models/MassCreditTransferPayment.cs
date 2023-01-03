using System.Text.Json.Serialization;

namespace HellenicBankOpenAPI.Hellenic.Models;

public class MassCreditTransferPayment
{
    public String CustomerReference { get; set; }
    public String ExecutionDate { get; set; }
    public String Amount { get; set; }
    public String Currency { get; set; }
    public String PaymentNotes { get; set; }
    public String BeneficiaryName { get; set; }
    public String BeneficiaryAccount { get; set; }
    public String BeneficiaryBankName { get; set; }
    public String BeneficiaryBankCountry { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? BeneficiaryBankAddress { get; set; }

    [JsonPropertyName("beneficiaryBankBic")]
    public String BeneficiaryBankBIC { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? BeneficiaryAddress { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? IntermediaryInstitutionBic { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? Charges { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? TransactionUrgency { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? ClearingHouseCode { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? EmailConfirmation { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? BeneficiaryCountry { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public String? FaxConfirmation { get; set; }
}
