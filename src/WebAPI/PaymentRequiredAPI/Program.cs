using PaymentRequired.Contracts;
using PaymentRequired.Middlewares;
using PaymentRequired.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(
    config =>
    {
        config.AddConsole();
        config.AddDebug();
    }
    );
builder.Services.AddScoped<IPaymentRequiredValidator, NoPaymentIsRequiredValidator>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<PaymentRequiredMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
