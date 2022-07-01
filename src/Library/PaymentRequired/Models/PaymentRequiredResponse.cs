using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRequired.Models
{
    public class PaymentRequiredResponse
    {
        public PaymentRequiredResponse()
        {
            this.TitleReason = string.Empty;
            this.DetailedReason = string.Empty;
            this.IsPaymentRequired = true;
        }
        public bool IsPaymentRequired { get; internal set; }
        public string DetailedReason { get; internal set; }
        public string TitleReason { get; internal set; }
    }
}
