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
        public bool IsPaymentRequired { get; set; }
        public string DetailedReason { get; set; }
        public string TitleReason { get; set; }
    }
}
