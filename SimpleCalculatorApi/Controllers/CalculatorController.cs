using Microsoft.AspNetCore.Mvc;
using SimpleCalculator;
using SimpleCalculator.Interfaces;
using SimpleCalculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly IEnumerable<ICalculatorOperation> _operations;
        private readonly Calculator _calculator;

        public CalculatorController(IEnumerable<ICalculatorOperation> operations, Calculator calculator)
        {
            _operations = operations;
            _calculator = calculator;
        }

        [HttpGet("add")]
        public IActionResult Add(double a, double b)
        {
            var operation = _operations.FirstOrDefault(op => op is Addition);
            if (operation == null) return NotFound("Addition operation not found");
            
            return Ok(_calculator.Calculate(a, b, operation));
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(double a, double b)
        {
            var operation = _operations.FirstOrDefault(op => op is Subtraction);
            if (operation == null) return NotFound("Subtraction operation not found");
            
            return Ok(_calculator.Calculate(a, b, operation));
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(double a, double b)
        {
            var operation = _operations.FirstOrDefault(op => op is Multiplication);
            if (operation == null) return NotFound("Multiplication operation not found");
            
            return Ok(_calculator.Calculate(a, b, operation));
        }

        [HttpGet("divide")]
        public IActionResult Divide(double a, double b)
        {
            var operation = _operations.FirstOrDefault(op => op is Division);
            if (operation == null) return NotFound("Division operation not found");
            
            try
            {
                return Ok(_calculator.Calculate(a, b, operation));
            }
            catch (DivideByZeroException)
            {
                return BadRequest("Division by zero is not allowed.");
            }
        }
    }
}