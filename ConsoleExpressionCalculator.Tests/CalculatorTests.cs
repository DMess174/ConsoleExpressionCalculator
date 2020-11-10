using ConsoleExpressionCalculator.Parsers;
using ConsoleExpressionCalculator.Symbols;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConsoleExpressionCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Mock<IParser> _parser;
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _parser = new Mock<IParser>();
            _calculator = new Calculator();
        }

        [Test]
        public void CalculateAddition()
        {
            var expression = "1 + 1";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(1),
                new OperationSymbol(OperationTypes.Add),
                new NumberSymbol(1),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CalculateSubtract()
        {
            var expression = "14 - 11";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(14),
                new OperationSymbol(OperationTypes.Subtract),
                new NumberSymbol(11),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(3, result);
        }

        [Test]
        public void CalculateMultiply()
        {
            var expression = "11 * 11";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(11),
                new OperationSymbol(OperationTypes.Multiply),
                new NumberSymbol(11),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(121, result);
        }

        [Test]
        public void CalculateDivide()
        {
            var expression = "121.4 / 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(121.4),
                new OperationSymbol(OperationTypes.Divide),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(60.7, result);
        }

        [Test]
        public void CalculateUnarySubtract()
        {
            var expression = "- 11.21 + 1";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new OperationSymbol(OperationTypes.Subtract),
                new NumberSymbol(11.21),
                new OperationSymbol(OperationTypes.Add),
                new NumberSymbol(1),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(-10.21, result);
        }

        [Test]
        public void CalculateExpressionWithPriority()
        {
            var expression = "2 + 2 * 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new NumberSymbol(2),
                new OperationSymbol(OperationTypes.Add),
                new NumberSymbol(2),
                new OperationSymbol(OperationTypes.Multiply),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void CalculateExpressionWithBrackets()
        {
            var expression = "(2 + 2) * 2";

            _parser.Setup(i => i.Parse(expression)).Returns(new List<Symbol>
            {
                new SpecialSymbol(SpecialSymbolTypes.OpenBracket),
                new NumberSymbol(2),
                new OperationSymbol(OperationTypes.Add),
                new NumberSymbol(2),
                new SpecialSymbol(SpecialSymbolTypes.CloseBracket),
                new OperationSymbol(OperationTypes.Multiply),
                new NumberSymbol(2),
            });

            var result = _calculator.Calculate(expression);

            Assert.AreEqual(8, result);
        }

        [Test]
        public void CalculateThrowFormatExceptionWrongNumberOfBrackets()
        {
            var expression = "- 35+(85.5)+(*35/5+";

            Assert.Throws<FormatException>(() => _calculator.Calculate(expression));
        }

        [Test]
        public void CalculateThrowFormatExceptionUnexpectedSymbol()
        {
            var expression = "-35+85.5*n35/5+";

            Assert.Throws<FormatException>(() => _calculator.Calculate(expression));
        }
    }
}