namespace VatCalculatorApi.Services;

using VatCalculatorApi.Models;

public class VatService : IVatService
{
    public VatResponse Calculate(decimal amount, decimal vatRate)
    {
        // All business logic lives here
        var vatAmount = amount * vatRate;
        var total = amount + vatAmount;

        return new VatResponse
        {
            BaseAmount = Math.Round(amount, 2),
            VatAmount = Math.Round(vatAmount, 2),
            TotalAmount = Math.Round(total, 2),
            VatRate = vatRate,
            Currency = "NGN"
        };
    }
}