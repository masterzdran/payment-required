using Microsoft.AspNetCore.Http;
using PaymentRequired.Models;

namespace PaymentRequired.Contracts
{
    public interface IPaymentRequiredValidator
    {
        bool IsPaymentRequired();
        PaymentRequiredResponse ValidatePaymentRequired(HttpContext context);
    }
}
