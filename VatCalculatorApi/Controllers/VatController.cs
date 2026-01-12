using Microsoft.AspNetCore.Mvc;
using VatCalculatorApi.Models;

namespace VatCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VatController : ControllerBase
    {
        private readonly IVatService _vatService;

        private readonly ILogger<VatController> _logger;

        public VatController(ILogger<VatController> logger, IVatService vatService)
        {
            _logger = logger;
            _vatService = vatService;
        }

        /// <summary>
        /// Calculate VAT using JSON body (recommended for complex requests)
        /// </summary>
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(VatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Calculate([FromBody] VatRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _vatService.Calculate(request.Amount, request.VatRate);
            return Ok(response);
        }

        /// <summary>
        /// Quick VAT calculation via query parameters
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(VatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery] decimal amount, [FromQuery] decimal? vatRate = 0.075m)
        {
            if (amount <= 0)
            {
                return BadRequest(new { Error = "Amount must be positive and greater than zero." });
            }

            if (vatRate < 0 || vatRate > 1)
            {
                return BadRequest(new { Error = "VAT rate must be between 0 and 1 (decimal)." });
            }

            var response = _vatService.Calculate(amount, vatRate.Value);
            return Ok(response);
        }
    }
}
