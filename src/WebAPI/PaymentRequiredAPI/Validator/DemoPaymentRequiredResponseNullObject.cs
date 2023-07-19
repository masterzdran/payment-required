using PaymentRequired.Models;

namespace PaymentRequiredAPI.Validator
{
    internal class DemoPaymentRequiredResponseNullObject : PaymentRequiredResponse
    {
        public DemoPaymentRequiredResponseNullObject() : base()
        {
            this.IsPaymentRequired = true;
            this.TitleReason = @"Rejectiong for demo purposes.";
            this.DetailedReason = @"The request is rejected for demonstration purposes";
        }
    }
}
