using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        #region ENDPOINTS

        #region SOMA
        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ($"Soma: {firstNumber} + {secondNumber} = {ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) }");
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        #endregion

        #region SUBTRAÇÃO
        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ($"Subtração: {firstNumber} - {secondNumber} = {ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber)}");
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }
        #endregion

        #region MULTIPLICAÇÃO
        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ($"Multiplicação: {firstNumber} * {secondNumber} = {ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber)}");
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }
        #endregion

        #region DIVISÃO
        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ($"Divisão: {firstNumber} / {secondNumber} = {ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber)}");
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }
        #endregion

        #region MÉDIA
        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var med = ($"Média: ({firstNumber} + {secondNumber}) /2 = {(ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2}");
                return Ok(med.ToString());
            }
            return BadRequest("Invalid Input");
        }
        #endregion

        #region RAIZ QUADRADA
        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Raiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var rai = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok($"Raiz Quadrada: √{firstNumber} = {rai.ToString()}");
            }
            return BadRequest("Invalid Input");
        }
        #endregion

        #endregion

        #region MÉTODOS/VALIDAÇÕES

        // Método que valida se o valor passado na req é numérico
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

        }

        // Método que converte os valores de string para decimal
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        #endregion
    }
}
