# ![Payment Required](https://raw.githubusercontent.com/masterzdran/payment-required/8d35b984d03e89e70763ec96b4340d5357b964d1/icon.64.png "payment-required")  Payment Required

This library intend to add a simple interface to your API, if a client of a Software-as-a-Service (SaaS) has their payments in order.

A middleware component is added to the middleware pipeline, and is injected with a instance of an object that implements IPaymentRequiredValidator with your "business rules" validation.

The response of the API will be either the result of the service if everything is OK, or a ProblemDetails with the description of the exception.



# Configuration

## 1- Create an class that implements IPaymentRequiredValidator

```csharp
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
			// implement your own business logic
			// ...
            return _paymentRequiredResponse;
        }
    }
```


## 2- Add IPaymentRequiredValidator to Dependency Injection Container
We need  to inject **IPaymentRequiredValidator**, one of the **PaymentRequiredMiddleware** dependencies.
```csharp
	// ... previous application configurations and dependencies
	builder.Services.AddScoped<IPaymentRequiredValidator, NoPaymentIsRequiredValidator>();
	// ... even more application configurations.
```
## 3- Add PaymentRequiredMiddleware to middleware pipeline

Add **PaymentRequiredMiddleware** into the pipeline, between UseAuthentication and UseAuthorization. You need to identify your "client" in order to verify if payment is due or not. 

```csharp
	app.UseAuthentication();

	app.UseMiddleware<PaymentRequiredMiddleware>(); 
	
	app.UseAuthorization();
```

# Credits
- @masterzdran

# Attribution

Payment method icons created by [Freepik - Flaticon](https://www.flaticon.com/free-icons/payment-method)
