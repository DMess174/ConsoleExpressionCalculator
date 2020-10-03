using System.Globalization;
using System.IO;
using System.Text;

namespace ConsoleExpressionCalculator
{
    public class SymbolResolver
    {
        private readonly TextReader _reader;
        private char _currentChar;

        public double Number { get; private set; }
        public Symbol CurrentSymbol { get; private set; }

        public SymbolResolver(TextReader reader)
        {
            _reader = reader;
            NextChar();
            NextSymbol();
        }

        public void NextSymbol()
        {
            if (IsSpecialSymbol())
                return;

            GetNumber();
        }

        private void NextChar()
        {
            int ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }

        private bool IsSpecialSymbol()
        {
            switch (_currentChar)
            {
                case '\0':
                    CurrentSymbol = Symbol.EOE;
                    return true;

                case '+':
                    NextChar();
                    CurrentSymbol = Symbol.Add;
                    return true;

                case '-':
                    NextChar();
                    CurrentSymbol = Symbol.Subtract;
                    return true;

                case '*':
                    NextChar();
                    CurrentSymbol = Symbol.Multiply;
                    return true;

                case '/':
                    NextChar();
                    CurrentSymbol = Symbol.Divide;
                    return true;

                case '(':
                    NextChar();
                    CurrentSymbol = Symbol.OpenBracket;
                    return true;

                case ')':
                    NextChar();
                    CurrentSymbol = Symbol.CloseBracket;
                    return true;

                default:
                    return false;
            }
        }

        private void GetNumber()
        {
            if (char.IsDigit(_currentChar) || _currentChar == '.')
            {
                var builder = new StringBuilder();
                bool isDouble = false;
                while (char.IsDigit(_currentChar) || !isDouble && _currentChar == '.')
                {
                    builder.Append(_currentChar);
                    isDouble = _currentChar == '.';
                    NextChar();
                }

                Number = double.Parse(builder.ToString(), CultureInfo.InvariantCulture);
                CurrentSymbol = Symbol.Number;
                return;
            }
        }
    }
}
