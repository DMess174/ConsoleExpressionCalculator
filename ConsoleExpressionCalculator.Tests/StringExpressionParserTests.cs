using ConsoleExpressionCalculator.Parsers;
using ConsoleExpressionCalculator.Symbols;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleExpressionCalculator.Tests
{
    [TestFixture]
    public class StringExpressionParserTests
    {
        private IParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new StringExpressionParser();
        }

        [Test]
        public void ParseSuccessfully()
        {
            var expression = "- 35+85.5*(35/5)";

            IList<Symbol> expectedSymbols = new List<Symbol>()
            {
                new OperationSymbol(OperationTypes.Subtract),
                new NumberSymbol(35),
                new OperationSymbol(OperationTypes.Add),
                new NumberSymbol(85.5),
                new OperationSymbol(OperationTypes.Multiply),
                new SpecialSymbol(SpecialSymbolTypes.OpenBracket),
                new NumberSymbol(35),
                new OperationSymbol(OperationTypes.Divide),
                new NumberSymbol(5),
                new SpecialSymbol(SpecialSymbolTypes.CloseBracket),
            };

            var result = _parser.Parse(expression);

            Assert.AreEqual(expectedSymbols.Count, result.Count);

            for(int i = 0; i < result.Count; i++)
            {
                Assert.IsTrue(expectedSymbols[i].Type == result[i].Type);

                if (expectedSymbols[i] is OperationSymbol expectedOperationSymbol && result[i] is OperationSymbol resultOperationSymbol)
                {
                    Assert.IsTrue(expectedOperationSymbol.OperationType == resultOperationSymbol.OperationType);
                }

                else if (expectedSymbols[i] is NumberSymbol expectedNumberSymbol && result[i] is NumberSymbol resultNumberSymbol)
                {
                    Assert.IsTrue(expectedNumberSymbol.Number == resultNumberSymbol.Number);
                }

                else if (expectedSymbols[i] is SpecialSymbol expectedSpecialSymbol && result[i] is SpecialSymbol resultSpecialSymbol)
                {
                    Assert.IsTrue(expectedSpecialSymbol.SpecialType == resultSpecialSymbol.SpecialType);
                }
            }
        }
    }
}