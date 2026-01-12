using System.ComponentModel.DataAnnotations;

namespace VatCalculatorApi.Models
{
    public class VatRequest
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive and greater than zero.")]
        public decimal Amount { get; set; }

        [Range(0, 1, ErrorMessage = "VAT rate must be between 0 and 100% (as decimal).")]
        public decimal VatRate { get; set; } = 0.075m;  // Default: Nigeria standard 7.5%
    }
}
