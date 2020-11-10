using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ConsoleExpressionCalculator.Symbols;

namespace ConsoleExpressionCalculator.Parsers
{
    public class StringExpressionParser : IParser
    {
        public IList<Symbol> Parse(string expression)
        {
            var chars = expression.Replace(" ", "");

            var result = ResolveChars(chars);

            return result;
        }

        private IList<Symbol> ResolveChars(string expression)
        {
            var symbols = new List<Symbol>();

            for (int index = 0; index < expression.Length; index++)
            {
                if (char.IsDigit(expression[index]) || expression[index] == '.')
                {
                    var number = GetNumber(expression, index, out index);

                    symbols.Add(new NumberSymbol(number));
                    continue;
                }

                switch (expression[index])
                {
                    case '+':
                        symbols.Add(new OperationSymbol(OperationTypes.Add));
                        break;
                    case '-':
                        symbols.Add(new OperationSymbol(OperationTypes.Subtract));
                        break;
                    case '*':
                        symbols.Add(new OperationSymbol(OperationTypes.Multiply));
                        break;
                    case '/':
                        symbols.Add(new OperationSymbol(OperationTypes.Divide));
                        break;
                    case '(':
                        symbols.Add(new SpecialSymbol(SpecialSymbolTypes.OpenBracket));
                        break;
                    case ')':
                        symbols.Add(new SpecialSymbol(SpecialSymbolTypes.CloseBracket));
                        break;
                    default:
                        throw new FormatException($"Unexpect symbol {expression[index]}");
                };
            }
            return symbols;
        }

        private double GetNumber(string expression, int index, out int currentIndex)
        {
            var stringNumber = new StringBuilder();
            bool isDouble = false;

            while (index < expression.Length)
            {
                if (char.IsDigit(expression[index]) || !isDouble && expression[index] == '.')
                {
                    stringNumber.Append(expression[index]);
                    isDouble = expression[index] == '.';
                    index += 1;
                    continue;
                }
                break;
            }

            currentIndex = index - 1;

            var number = double.Parse(stringNumber.ToString(), CultureInfo.InvariantCulture);

            return number;
        }
    }
}
