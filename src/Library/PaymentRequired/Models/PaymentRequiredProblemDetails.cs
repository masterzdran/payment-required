using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentRequired.Models
{
    public sealed class PaymentRequiredProblemDetails : ProblemDetails
    {
        private readonly string _url = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2";
        public PaymentRequiredProblemDetails()
        {
            this.Status = StatusCodes.Status402PaymentRequired;
            this.Type = _url;
        }
    }
}
