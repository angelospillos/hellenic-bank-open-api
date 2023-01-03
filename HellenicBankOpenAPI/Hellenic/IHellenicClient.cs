using HellenicBankOpenAPI.Hellenic.Models;
using Refit;

namespace HellenicBankOpenAPI.Hellenic;

public interface IHellenicClient
{
    [Post("/v1/b2b/credit/transfer")]
    Task<PaymentResponse> CreditTransfer(
        CreditTransfer transfer,
        [Authorize("Bearer")] string token,
        [Header("x-client-id")] string clientId);


    [Get("/v1/b2b/credit/transfer")]
    Task<ResponseWrapper<PaymentStatusReport>> GetCreditTransfer(
        [Authorize("Bearer")] string token,
        [Header("x-client-id")] string clientId,
        [Query] GetCreditTransferParams urlParams
    );

    [Post("/v1/b2b/credit/transfer/mass")]
    Task<PaymentResponse> MassCreditTransfer(
        MassCreditTransfer transfer,
        [Authorize("Bearer")] string token,
        [Header("x-client-id")] string clientId);

    [Get("/v1/b2b/credit/transfer/mass")]
    Task<ResponseWrapper<MassPaymentStatusReport>> GetMassCreditTransfer(
        [Authorize("Bearer")] string token,
        [Header("x-client-id")] string clientId,
        [Query] GetMassCreditTransferParams urlParams
    );
}
