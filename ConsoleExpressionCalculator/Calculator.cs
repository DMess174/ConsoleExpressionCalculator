using ConsoleExpressionCalculator.Parsers;
using ConsoleExpressionCalculator.Tree;

namespace ConsoleExpressionCalculator
{
    public class Calculator
    {
        private readonly ITreeBuilder _builder;
        private readonly IParser _parser;

        public Calculator()
        {
            _parser = new StringExpressionParser();
            _builder = new TreeBuilder();
        }


        public double Calculate(string expression)
        {
            var symbols = _parser.Parse(expression);

            var tree = _builder.CreateTree(symbols);

            return tree.Evaluate();
        }
    }
}
