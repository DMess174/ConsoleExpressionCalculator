using System;
using System.IO;
using ConsoleExpressionCalculator.Tree;

namespace ConsoleExpressionCalculator
{
    public class StringExpressionParser
    {
        private readonly SymbolResolver _resolver;

        public StringExpressionParser(SymbolResolver resolver)
        {
            _resolver = resolver;
        }

        public static TreeNode Parse(string str)
        {
            return Parse(new SymbolResolver(new StringReader(str)));
        }

        private static TreeNode Parse(SymbolResolver resolver)
        {
            var parser = new StringExpressionParser(resolver);
            return parser.ParseExpression();
        }

        public TreeNode ParseExpression()
        {
            var expr = GetNode();

            if (_resolver.CurrentSymbol != Symbol.EOE)
                throw new Exception("Unexpected characters at end of expression");

            return expr;
        }

        private TreeNode GetNode()
        {
            var leftSideNode = GetMultiplyDevideNode();

            while (true)
            {
                Func<double, double, double> @operator = null;
                switch (_resolver.CurrentSymbol)
                {
                    case Symbol.Add:
                        @operator = (a, b) => a + b;
                        break;
                    case Symbol.Subtract:
                        @operator = (a, b) => a - b;
                        break;
                }

                if (@operator == null)
                    return leftSideNode;

                _resolver.NextSymbol();

                var rightSideNode = GetMultiplyDevideNode();

                leftSideNode = new BinaryOperationNode(leftSideNode, rightSideNode, @operator);
            }
        }

        private TreeNode GetMultiplyDevideNode()
        {
            var leftSideNode = GetUnaryNode();

            while (true)
            {
                Func<double, double, double> @operator = null;
                switch (_resolver.CurrentSymbol)
                {
                    case Symbol.Multiply:
                        @operator = (a, b) => a * b;
                        break;
                    case Symbol.Divide:
                        @operator = (a, b) => a / b;
                        break;
                }

                if (@operator == null)
                    return leftSideNode;

                _resolver.NextSymbol();

                var rightSideNode = GetUnaryNode();

                leftSideNode = new BinaryOperationNode(leftSideNode, rightSideNode, @operator);
            }
        }


        private TreeNode GetUnaryNode()
        {
            while (true)
            {
                if (_resolver.CurrentSymbol == Symbol.Add)
                {
                    _resolver.NextSymbol();
                    continue;
                }

                if (_resolver.CurrentSymbol == Symbol.Subtract)
                {
                    _resolver.NextSymbol();
                    var rightSideNode = GetUnaryNode();

                    return new UnaryOperatorNode(rightSideNode, (a) => -a);
                }

                return GetNodeLeaf();
            }
        }

        private TreeNode GetNodeLeaf()
        {
            if (_resolver.CurrentSymbol == Symbol.Number)
            {
                var node = new NumberNode(_resolver.Number);
                _resolver.NextSymbol();

                return node;
            }

            if (_resolver.CurrentSymbol == Symbol.OpenBracket)
            {
                _resolver.NextSymbol();

                var node = GetNode();

                if (_resolver.CurrentSymbol != Symbol.CloseBracket)
                    throw new Exception("Missing close bracket");

                _resolver.NextSymbol();

                return node;
            }

            throw new Exception($"Unexpect symbol: {_resolver.CurrentSymbol}");
        }
    }
}
