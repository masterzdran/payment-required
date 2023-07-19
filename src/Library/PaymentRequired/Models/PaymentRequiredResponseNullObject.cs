namespace PaymentRequired.Models
{
    public sealed class NoPaymentIsRequiredResponseNullObject : PaymentRequiredResponse
    {
        public NoPaymentIsRequiredResponseNullObject() : base()
        {
            this.IsPaymentRequired = false;
            this.TitleReason = string.Empty;
            this.DetailedReason = string.Empty;
        }
    }
}
