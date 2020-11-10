namespace ConsoleExpressionCalculator.Symbols
{
    public class NumberSymbol : Symbol
    {
        public override SymbolType Type => SymbolType.Number;

        public double Number { get; }

        public NumberSymbol(double number)
        {
            Number = number;
        }
    }
}
