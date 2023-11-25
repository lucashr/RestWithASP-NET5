using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtration = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtration.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                if (ConvertToDecimal(secondNumber) > 0)
                {

                    var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                    return Ok(division.ToString());

                }
                
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(mean.ToString());
            }

            return BadRequest("Invalid Input");

        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {

            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Input");

        }

        private decimal ConvertToDecimal(string strNumber)
        {

            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;

        }

        private bool IsNumeric(string strNumber)
        {

            double number;
            bool isNumber = double.TryParse(strNumber,System.Globalization.NumberStyles.Any,
                                            System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            
            return isNumber;

        }
    }
}