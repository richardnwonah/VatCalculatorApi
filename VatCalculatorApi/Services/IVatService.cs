using VatCalculatorApi.Models;

namespace VatCalculatorApi.Services;

public interface IVatService
{
    VatResponse Calculate(decimal amount, decimal vatRate);
}