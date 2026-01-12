namespace VatCalculatorApi.Models
{
    public class VatResponse
    {
        public decimal BaseAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal VatRate { get; set; }
        public string Currency { get; set; } = "NGN";
    }
}
