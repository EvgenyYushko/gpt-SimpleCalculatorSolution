using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleCalculator;
using SimpleCalculator.Operations;
using ICalculatorOperation = SimpleCalculator.ICalculatorOperation;

namespace SimpleCalculatorApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculatorController : ControllerBase
	{
		private readonly IEnumerable<ICalculatorOperation> _operations;
		private readonly Calculator _calculator;

		// Конструктор контроллера принимает операции и калькулятор
		public CalculatorController(IEnumerable<ICalculatorOperation> operations, Calculator calculator)
		{
			_operations = operations;
			_calculator = calculator;
		}

		// Метод для сложения двух чисел
		[HttpGet("add")]
		public IActionResult Add(double a, double b)
		{
			var operation = _operations.FirstOrDefault(op => op is Addition);
			if (operation == null) return NotFound("Addition operation not found");

			return Ok(_calculator.Calculate(a, b, operation));
		}

		// Метод для вычитания двух чисел
		[HttpGet("subtract")]
		public IActionResult Subtract(double a, double b)
		{
			var operation = _operations.FirstOrDefault(op => op is Subtraction);
			if (operation == null) return NotFound("Subtraction operation not found");

			return Ok(_calculator.Calculate(a, b, operation));
		}

		// Метод для умножения двух чисел
		[HttpGet("multiply")]
		public IActionResult Multiply(double a, double b)
		{
			var operation = _operations.FirstOrDefault(op => op is Multiplication);
			if (operation == null) return NotFound("Multiplication operation not found");

			return Ok(_calculator.Calculate(a, b, operation));
		}

		// Метод для деления двух чисел
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