using Microsoft.AspNetCore.Http;
using PaymentRequired.Contracts;

namespace PaymentRequired.Models
{
    public sealed class NoPaymentIsRequiredValidator : IPaymentRequiredValidator
    {
        private readonly PaymentRequiredResponse _paymentRequiredResponse;
        public NoPaymentIsRequiredValidator()
        {
            this._paymentRequiredResponse = new NoPaymentIsRequiredResponseNullObject();
        }
        public bool IsPaymentRequired()
        {
            return _paymentRequiredResponse.IsPaymentRequired;
        }
        public PaymentRequiredResponse ValidatePaymentRequired(HttpContext context)
        {
            return _paymentRequiredResponse;
        }
    }
}
