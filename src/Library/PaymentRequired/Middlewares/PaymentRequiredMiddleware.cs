using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PaymentRequired.Contracts;
using PaymentRequired.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentRequired.Middlewares
{
    public sealed class PaymentRequiredMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPaymentRequiredValidator _validator;
        private readonly ILogger _logger;
        
        public PaymentRequiredMiddleware(ILogger<PaymentRequiredMiddleware> logger, IPaymentRequiredValidator paymentRequiredValidator,RequestDelegate next)
        {
            this._logger = logger;
            this._next = next;
            this._validator = paymentRequiredValidator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            PaymentRequiredResponse paymentRequired = _validator.ValidatePaymentRequired(context);

            
            if (paymentRequired.IsPaymentRequired)
            {
                string instance = context.Request.Path;
                PaymentRequiredProblemDetails problemDetails = new PaymentRequiredProblemDetails
                {
                    Title = paymentRequired.TitleReason,
                    Detail = paymentRequired.DetailedReason,
                    Instance = instance
                };
                int status = problemDetails.Status.GetValueOrDefault();
                var body = JsonSerializer.Serialize(problemDetails);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = status;
                await context.Response.WriteAsync(body);
                return;
            }
            await _next(context);
            return;
            
        }
    }
}
