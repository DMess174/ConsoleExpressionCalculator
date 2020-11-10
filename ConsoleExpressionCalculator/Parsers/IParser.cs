using ConsoleExpressionCalculator.Symbols;
using System.Collections.Generic;

namespace ConsoleExpressionCalculator.Parsers
{
    public interface IParser
    {
        IList<Symbol> Parse(string expression);
    }
}
