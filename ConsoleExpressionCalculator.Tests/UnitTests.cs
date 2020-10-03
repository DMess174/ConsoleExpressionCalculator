using NUnit.Framework;
using System.IO;

namespace ConsoleExpressionCalculator.Tests
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SymbolIdentifierTest()
        {
            var testString = "13 + 20 * (01 - 34.001) / 004.145";
            var t = new SymbolResolver(new StringReader(testString));

            // "10"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Number);
            Assert.AreEqual(t.Number, 13);
            t.NextSymbol();

            // "+"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Add);
            t.NextSymbol();

            // "20"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Number);
            Assert.AreEqual(t.Number, 20);
            t.NextSymbol();

            // "*"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Multiply);
            t.NextSymbol();

            // "("
            Assert.AreEqual(t.CurrentSymbol, Symbol.OpenBracket);
            t.NextSymbol();

            // "01"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Number);
            Assert.AreEqual(t.Number, 1);
            t.NextSymbol();

            // "-"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Subtract);
            t.NextSymbol();

            // "34.001"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Number);
            Assert.AreEqual(t.Number, 34.001);
            t.NextSymbol();

            // ")"
            Assert.AreEqual(t.CurrentSymbol, Symbol.CloseBracket);
            t.NextSymbol();

            // "/"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Divide);
            t.NextSymbol();

            // "004.145"
            Assert.AreEqual(t.CurrentSymbol, Symbol.Number);
            Assert.AreEqual(t.Number, 4.145);
            t.NextSymbol();
        }
    }
}