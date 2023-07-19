using PaymentRequired.Contracts;
using PaymentRequired.Models;

namespace PaymentRequiredAPI.Validator
{
    public sealed class DemoPaymentRequiredValidator : IPaymentRequiredValidator
    {
        private readonly DemoPaymentRequiredResponseNullObject _paymentRequiredResponse;

        public DemoPaymentRequiredValidator()
        {
            this._paymentRequiredResponse = new DemoPaymentRequiredResponseNullObject();
        }
        public bool IsPaymentRequired()
        {
            // all business code to validate if the request is required or not            
            return false;
        }

        public PaymentRequiredResponse ValidatePaymentRequired(HttpContext context)
        {
            return this.IsPaymentRequired() ?
                new DemoPaymentRequiredResponseNullObject() :
                _paymentRequiredResponse;
        }
    }
}
