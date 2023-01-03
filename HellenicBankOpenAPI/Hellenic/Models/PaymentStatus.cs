namespace HellenicBankOpenAPI.Hellenic.Models;

public class PaymentStatus
{
    public String Status { get; set; }
    public String ProcessDateTime { get; set; }
    public Decimal ChargeAmount1 { get; set; }
    public Decimal ChargeAmount2 { get; set; }
    public Decimal ChargeAmount3 { get; set; }
    public Decimal TotalDebitAmount { get; set; }
    public Decimal TotalCRAmount { get; set; }
    public Decimal HandlingChargeAmount { get; set; }
    public Decimal SameDayChargeAmount { get; set; }
    public Decimal SwiftCreationChargeAmount { get; set; }
    public Decimal ExchangeRateChargeAmount { get; set; }
    public Decimal OurChargeAmount { get; set; }
    public Decimal LocalFaxChargeAmount { get; set; }
    public Decimal AbroadFaxChargeAmount { get; set; }
    public Decimal EmailChargeAmount { get; set; }
    public Decimal WrongIBANChargeAmount { get; set; }
    public Decimal EmailFaxChargeAmount { get; set; }
    public Decimal Over8kChargeAmount { get; set; }
    public Decimal ExchangeRate { get; set; }
}
